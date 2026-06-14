using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/ediciones")]
public class EdicionesController : CrudController<Edicion>
{
    public EdicionesController(FestCineDbContext db) : base(db) { }

    [HttpGet("actual")]
    public async Task<ActionResult<Edicion>> GetActual()
    {
        var edicion = await Db.Ediciones.AsNoTracking()
            .FirstOrDefaultAsync(e => e.EstadoEdicion == "Actual");

        return edicion is null ? NotFound(new { mensaje = "No existe una edicion actual." }) : edicion;
    }
}
