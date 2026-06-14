using FestCineApi.DTOs;
using FestCineApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/taquilla")]
public class TaquillaController : ControllerBase
{
    private readonly FestCineService _service;

    public TaquillaController(FestCineService service)
    {
        _service = service;
    }

    [HttpPost("comprar-entrada")]
    public async Task<IActionResult> ComprarEntrada([FromBody] CompraEntradaRequest request)
    {
        try
        {
            var response = await _service.ComprarEntradaAsync(request);
            return response is null
                ? BadRequest(new { mensaje = "No se pudo completar la compra." })
                : Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }
}
