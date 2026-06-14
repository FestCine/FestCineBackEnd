using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/sede-ediciones")]
public class SedeEdicionesController : ControllerBase
{
    private readonly FestCineDbContext _db;

    public SedeEdicionesController(FestCineDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<SedeEdicion>>> GetAll()
    {
        return await _db.SedeEdiciones
            .AsNoTracking()
            .OrderBy(x => x.IdEdicion)
            .ThenBy(x => x.IdSede)
            .ToListAsync();
    }

    [HttpGet("{idSede}/{idEdicion}")]
    public async Task<ActionResult<SedeEdicion>> GetById(string idSede, string idEdicion)
    {
        var item = await _db.SedeEdiciones.FindAsync(idSede, idEdicion);
        return item is null ? NotFound() : item;
    }

    [HttpPost]
    public async Task<ActionResult<SedeEdicion>> Create([FromBody] SedeEdicion item)
    {
        try
        {
            _db.SedeEdiciones.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpPut("{idSede}/{idEdicion}")]
    public async Task<IActionResult> Update(string idSede, string idEdicion, [FromBody] SedeEdicion item)
    {
        try
        {
            var existing = await _db.SedeEdiciones.FindAsync(idSede, idEdicion);
            if (existing is null) return NotFound();

            // Como la PK esta compuesta por los dos campos, no se permite cambiarla desde PUT.
            // Para cambiar la relacion, elimina la anterior y crea una nueva.
            existing.IdSede = idSede;
            existing.IdEdicion = idEdicion;

            await _db.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpDelete("{idSede}/{idEdicion}")]
    public async Task<IActionResult> Delete(string idSede, string idEdicion)
    {
        try
        {
            var item = await _db.SedeEdiciones.FindAsync(idSede, idEdicion);
            if (item is null) return NotFound();

            _db.SedeEdiciones.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }
}
