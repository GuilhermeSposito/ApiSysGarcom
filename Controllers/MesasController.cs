using ApiSysGarcom.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSysGarcom.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
[Authorize]
public class MesasController : Controller
{
    private readonly AppDbContext _context;

    public MesasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetMesas()
    {
        var mesas = await _context.Mesas.Where(x=> !x.Codigo!.Contains("B") && !x.Codigo!.Contains("E")).ToListAsync();

        return Ok(mesas);
    }
}
