using Microsoft.AspNetCore.Mvc;
using SmartParkApi.Models;
using SmartParkApi.Services;

namespace SmartParkApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistraEntradasController : ControllerBase
{
    private readonly RegistraEntradaService _entradaService;

    public RegistraEntradasController(RegistraEntradaService entradaService)
    {
        _entradaService = entradaService;
    }

    // GET: api/registraentradas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegistraEntrada>>> GetEntradas()
    {
        var entradas = await _entradaService.ObtenerTodasAsync();
        return Ok(entradas);
    }

    // GET: api/registraentradas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RegistraEntrada>> GetEntrada(int id)
    {
        var entrada = await _entradaService.ObtenerPorIdAsync(id);

        if (entrada == null)
        {
            return NotFound();
        }

        return Ok(entrada);
    }

    // POST: api/registraentradas
    [HttpPost]
    public async Task<ActionResult> PostEntrada([FromBody] RegistraEntrada nuevaEntrada)
    {
        if (nuevaEntrada == null)
        {
            return BadRequest("Los datos de la entrada son inválidos.");
        }

        // Llamamos al servicio para insertar en la base de datos
        var idGenerado = await _entradaService.CrearAsync(nuevaEntrada);

        // Asignamos el ID generado al objeto para retornarlo en la respuesta
        nuevaEntrada.EntradaID = idGenerado;

        // Retorna un código 201 Created con la ruta para consultar el nuevo recurso y el objeto creado
        return CreatedAtAction(nameof(GetEntrada), new { id = idGenerado }, nuevaEntrada);
    }
}