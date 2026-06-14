using FestCineApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/reportes")]
public class ReportesController : ControllerBase
{
    private readonly FestCineService _service;

    public ReportesController(FestCineService service)
    {
        _service = service;
    }

    [HttpGet("ranking/{idEdicion}")]
    public async Task<IActionResult> Ranking(string idEdicion)
        => Ok(await _service.RankingAsync(idEdicion));

    [HttpGet("premiacion/{idEdicion}")]
    public async Task<IActionResult> Premiacion(string idEdicion)
        => Ok(await _service.ActaPremiacionAsync(idEdicion));

    [HttpGet("financiero/{idEdicion}")]
    public async Task<IActionResult> Financiero(string idEdicion)
        => Ok(await _service.InformeFinancieroAsync(idEdicion));
}
