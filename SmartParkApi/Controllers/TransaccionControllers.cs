using Microsoft.AspNetCore.Mvc;
using SmartParkApi.Models;
using SmartParkApi.Services;

namespace SmartParkApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransaccionesController(TransaccionService transaccionService) : ControllerBase
{
    private readonly TransaccionService _transaccionService = transaccionService;

    // GET: api/transacciones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaccion>>> GetTransacciones()
    {
        var transacciones = await _transaccionService.ObtenerTodasAsync();
        return Ok(transacciones);
    }

    // GET: api/transacciones/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Transaccion>> GetTransaccion(int id)
    {
        var transaccion = await _transaccionService.ObtenerPorIdAsync(id);

        if (transaccion == null)
        {
            return NotFound();
        }

        return Ok(transaccion);
    }

    // POST: api/transacciones
    [HttpPost]
    public async Task<ActionResult> PostTransaccion([FromBody] Transaccion nuevaTransaccion)
    {
        if (nuevaTransaccion == null)
        {
            return BadRequest("Los datos de la transacción son inválidos.");
        }

        var idGenerado = await _transaccionService.CrearAsync(nuevaTransaccion);
        nuevaTransaccion.TransaccionId = idGenerado;

        return CreatedAtAction(nameof(GetTransaccion), new { id = idGenerado }, nuevaTransaccion);
    }

    // PUT: api/transacciones/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransaccion(int id, [FromBody] Transaccion transaccionActualizada)
    {
        if (transaccionActualizada == null || id != transaccionActualizada.TransaccionId)
        {
            return BadRequest("El ID de la transacción no coincide.");
        }

        var actualizado = await _transaccionService.ActualizarAsync(transaccionActualizada);

        if (!actualizado)
        {
            return NotFound("No se encontró la transacción que deseas actualizar.");
        }

        return NoContent(); // 204 No Content
    }
}