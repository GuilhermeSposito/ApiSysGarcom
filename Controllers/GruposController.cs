using ApiSysGarcom.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSysGarcom.Controllers;


[Route("/api/v1/[controller]")]
[ApiController]
[Authorize]
public class GruposController : Controller
{
    private readonly AppDbContext _context;

    public GruposController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetGrupos()
    {
        var grupos = await _context.GruCard.ToListAsync();

        return Ok(grupos);
    }
}
