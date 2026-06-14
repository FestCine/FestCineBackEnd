using FestCineApi.DTOs;
using FestCineApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/abonos")]
public class AbonosController : ControllerBase
{
    private readonly FestCineService _service;

    public AbonosController(FestCineService service)
    {
        _service = service;
    }

    [HttpPost("vender")]
    public async Task<IActionResult> VenderAbono([FromBody] VentaAbonoRequest request)
    {
        try
        {
            var response = await _service.VenderAbonoAsync(request);
            return response is null
                ? BadRequest(new { mensaje = "No se pudo completar la venta de abono." })
                : Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }
}
