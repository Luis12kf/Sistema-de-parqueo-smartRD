using Microsoft.AspNetCore.Mvc;
using SmartParkApi.Models;
using SmartParkApi.Services;

namespace SmartParkApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistraSalidasController : ControllerBase
{
    private readonly RegistraSalidaService _salidaService;

    public RegistraSalidasController(RegistraSalidaService salidaService)
    {
        _salidaService = salidaService;
    }

    // GET: api/registrasalidas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegistraSalida>>> GetSalidas()
    {
        var salidas = await _salidaService.ObtenerTodasAsync();
        return Ok(salidas);
    }

    // GET: api/registrasalidas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RegistraSalida>> GetSalida(int id)
    {
        var salida = await _salidaService.ObtenerPorIdAsync(id);

        if (salida == null)
        {
            return NotFound();
        }

        return Ok(salida);
    }

    // POST: api/registrasalidas
    [HttpPost]
    public async Task<ActionResult> PostSalida([FromBody] RegistraSalida nuevaSalida)
    {
        if (nuevaSalida == null)
        {
            return BadRequest("Los datos de la salida son inválidos.");
        }

        // Inserta en la base de datos y obtiene el ID generado
        var idGenerado = await _salidaService.CrearAsync(nuevaSalida);

        nuevaSalida.SalidaID = idGenerado;

        // Retorna el código 201 Created con la ruta para consultar el registro creado
        return CreatedAtAction(nameof(GetSalida), new { id = idGenerado }, nuevaSalida);
    }
}