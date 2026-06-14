using FestCineApi.DTOs;
using FestCineApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/agenda")]
public class AgendaController : ControllerBase
{
    private readonly FestCineService _service;

    public AgendaController(FestCineService service)
    {
        _service = service;
    }

    [HttpPost("proyecciones")]
    public async Task<IActionResult> CrearProyeccion([FromBody] CrearProyeccionRequest request)
    {
        try
        {
            await _service.CrearProyeccionAsync(request);
            return Ok(new CrearProyeccionResponse
            {
                IdProyeccion = request.IdProyeccion,
                Mensaje = "Proyeccion creada correctamente."
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpPut("proyecciones/{idProyeccion}")]
    public async Task<IActionResult> ActualizarProyeccion(string idProyeccion, [FromBody] CrearProyeccionRequest request)
    {
        try
        {
            await _service.ActualizarProyeccionAsync(idProyeccion, request);
            return Ok(new CrearProyeccionResponse
            {
                IdProyeccion = idProyeccion,
                Mensaje = "Proyeccion actualizada correctamente."
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpPost("eventos")]
    public async Task<IActionResult> CrearEvento([FromBody] CrearEventoRequest request)
    {
        try
        {
            await _service.CrearEventoAsync(request);
            return Ok(new CrearEventoResponse
            {
                IdEvento = request.IdEvento,
                Mensaje = "Evento creado correctamente."
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpPut("eventos/{idEvento}")]
    public async Task<IActionResult> ActualizarEvento(string idEvento, [FromBody] CrearEventoRequest request)
    {
        try
        {
            await _service.ActualizarEventoAsync(idEvento, request);
            return Ok(new CrearEventoResponse
            {
                IdEvento = idEvento,
                Mensaje = "Evento actualizado correctamente."
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }
}
