using Microsoft.AspNetCore.Mvc;
using SmartParkApi.Models;
using SmartParkApi.Services;

namespace SmartParkApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarifasController : ControllerBase
{
    private readonly TarifaService _tarifaService;

    public TarifasController(TarifaService tarifaService)
    {
        _tarifaService = tarifaService;
    }

    // GET: api/tarifas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarifa>>> GetTarifas()
    {
        var tarifas = await _tarifaService.ObtenerTodasAsync();
        return Ok(tarifas);
    }

    // GET: api/tarifas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tarifa>> GetTarifa(int id)
    {
        var tarifa = await _tarifaService.ObtenerPorIdAsync(id);

        if (tarifa == null)
        {
            return NotFound();
        }

        return Ok(tarifa);
    }

    // POST: api/tarifas
    [HttpPost]
    public async Task<ActionResult> PostTarifa([FromBody] Tarifa nuevaTarifa)
    {
        if (nuevaTarifa == null)
        {
            return BadRequest("Los datos de la tarifa son inválidos.");
        }

        var idGenerado = await _tarifaService.CrearAsync(nuevaTarifa);
        nuevaTarifa.TarifaId = idGenerado;

        return CreatedAtAction(nameof(GetTarifa), new { id = idGenerado }, nuevaTarifa);
    }

    // PUT: api/tarifas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarifa(int id, [FromBody] Tarifa tarifaActualizada)
    {
        if (tarifaActualizada == null || id != tarifaActualizada.TarifaId)
        {
            return BadRequest("El ID especificado no coincide con la tarifa enviada.");
        }

        var actualizado = await _tarifaService.ActualizarAsync(tarifaActualizada);

        if (!actualizado)
        {
            return NotFound("No se encontró la tarifa a actualizar.");
        }

        return NoContent(); // 204 No Content para indicar actualización exitosa
    }
}