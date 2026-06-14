using FestCineApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    private readonly FestCineDbContext _db;

    public HealthController(FestCineDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var canConnect = await _db.Database.CanConnectAsync();
        return Ok(new
        {
            api = "FestCine API",
            estado = canConnect ? "Conectado a SQL Server" : "Sin conexion a SQL Server",
            fecha = DateTime.Now
        });
    }
}
