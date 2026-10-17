using Microsoft.AspNetCore.Mvc;
using SmartParkApi.Models;
using SmartParkApi.Services;

namespace SmartParkApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NivelesController : ControllerBase
{
    private readonly NivelService _nivelService;

    public NivelesController(NivelService nivelService)
    {
        _nivelService = nivelService;
    }

    // GET: api/niveles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Nivel>>> GetNiveles()
    {
        var niveles = await _nivelService.ObtenerTodosAsync();
        return Ok(niveles);
    }

    // GET: api/niveles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Nivel>> GetNivel(int id)
    {
        var nivel = await _nivelService.ObtenerPorIdAsync(id);

        if (nivel == null)
        {
            return NotFound();
        }

        return Ok(nivel);
    }
}