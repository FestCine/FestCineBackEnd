using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/participaciones-pelicula")]
public class ParticipacionesPeliculaController : ControllerBase
{
    private readonly FestCineDbContext _db;

    public ParticipacionesPeliculaController(FestCineDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<ParticipacionPelicula>>> GetAll()
    {
        return await _db.ParticipacionesPelicula
            .AsNoTracking()
            .OrderBy(x => x.IdPelicula)
            .ThenBy(x => x.IdPersonal)
            .ThenBy(x => x.IdRol)
            .ToListAsync();
    }

    [HttpGet("{idPersonal}/{idPelicula}/{idRol}")]
    public async Task<ActionResult<ParticipacionPelicula>> GetById(string idPersonal, string idPelicula, string idRol)
    {
        var item = await _db.ParticipacionesPelicula.FindAsync(idPersonal, idPelicula, idRol);
        return item is null ? NotFound() : item;
    }

    [HttpPost]
    public async Task<ActionResult<ParticipacionPelicula>> Create([FromBody] ParticipacionPelicula item)
    {
        try
        {
            _db.ParticipacionesPelicula.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpPut("{idPersonal}/{idPelicula}/{idRol}")]
    public async Task<IActionResult> Update(string idPersonal, string idPelicula, string idRol, [FromBody] ParticipacionPelicula item)
    {
        try
        {
            var existing = await _db.ParticipacionesPelicula.FindAsync(idPersonal, idPelicula, idRol);
            if (existing is null) return NotFound();

            // Como la PK esta compuesta por los tres campos, no se permite cambiarla desde PUT.
            // Para cambiar la relacion, elimina la anterior y crea una nueva.
            existing.IdPersonal = idPersonal;
            existing.IdPelicula = idPelicula;
            existing.IdRol = idRol;

            await _db.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpDelete("{idPersonal}/{idPelicula}/{idRol}")]
    public async Task<IActionResult> Delete(string idPersonal, string idPelicula, string idRol)
    {
        try
        {
            var item = await _db.ParticipacionesPelicula.FindAsync(idPersonal, idPelicula, idRol);
            if (item is null) return NotFound();

            _db.ParticipacionesPelicula.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }
}
