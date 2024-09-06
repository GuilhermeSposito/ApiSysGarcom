using ApiSysGarcom.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSysGarcom.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
[Authorize]
public class ProdutoController : Controller
{
    public readonly AppDbContext _context;

    public ProdutoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetProdutos()
    {

        return Ok(_context.Cardapio.ToList());
    }
}
