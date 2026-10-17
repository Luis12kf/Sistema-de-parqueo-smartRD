using Microsoft.AspNetCore.Mvc;
using SmartParkApi.Models;
using SmartParkApi.Services;

namespace SmartParkApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EspaciosController(EspacioService espacioService) : ControllerBase
{
    private readonly EspacioService _espacioService = espacioService;

    // GET: api/espacios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Espacio>>> GetEspacios()
    {
        var espacios = await _espacioService.ObtenerTodosAsync();
        return Ok(espacios);
    }

    // GET: api/espacios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Espacio>> GetEspacio(int id)
    {
        var espacio = await _espacioService.ObtenerPorIdAsync(id);

        if (espacio == null)
        {
            return NotFound();
        }

        return Ok(espacio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEspacio(int id, [FromBody] Espacio espacioActualizado)
    {
        if (espacioActualizado == null || id != espacioActualizado.EspacioId)
        {
            return BadRequest("El ID del espacio no coincide.");
        }

        var actualizado = await _espacioService.ActualizarAsync(espacioActualizado);

        if (!actualizado)
        {
            return NotFound("No se encontró el espacio que deseas actualizar.");
        }

        return NoContent(); // Código 204: Actualización exitosa sin contenido que retornar
    }
}