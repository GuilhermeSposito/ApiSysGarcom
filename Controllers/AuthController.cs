using ApiSysGarcom.Context;
using ApiSysGarcom.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiSysGarcom.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        var Usuarios = await _context.Garcon.ToListAsync();
        var usuarioExiste = Usuarios.Any(x => x.Nome == loginModel.Usuario);

        if (!usuarioExiste)
        {
            return Unauthorized(new LoginResponse { Status = false, Message = "Usuário ou senha incorreto"});
        }

        var Usuario =  Usuarios.FirstOrDefault(x => x.Nome == loginModel.Usuario);

        if (loginModel.Senha != Usuario.Senha)
        {
            return Unauthorized(new LoginResponse { Status = false, Message = "Usuário ou senha incorreto" });
        }

        var ClaimsPrincipal = new ClaimsPrincipal(
            new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, Usuario.Nome!),
                new Claim("CODIGO", Usuario.Codigo!),
                new Claim("VALOR", Usuario.Valor.ToString())
            }, BearerTokenDefaults.AuthenticationScheme)
            );

        return SignIn(ClaimsPrincipal);   
    }

    [Authorize]
    [HttpGet("usuarioLogado")]
    public async Task<ActionResult> GetUsuarioLogado()
    {
        var user = User; 

        if(user.Identity?.IsAuthenticated ?? false)
        {
            var usuarios = await _context.Garcon.ToListAsync();
            var usuario = usuarios.FirstOrDefault(x => x.Nome == user.Identity?.Name);  

            return Ok(usuario);
        }

        return BadRequest();
    }
}
