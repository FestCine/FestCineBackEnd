using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/relaciones")]
public class RelacionesController : ControllerBase
{
    private readonly FestCineDbContext _db;

    public RelacionesController(FestCineDbContext db)
    {
        _db = db;
    }

    [HttpGet("pelicula-generos")]
    public async Task<ActionResult<List<PeliculaGenero>>> GetPeliculaGeneros()
        => await _db.PeliculaGeneros.AsNoTracking().ToListAsync();

    [HttpPost("pelicula-generos")]
    public async Task<IActionResult> AddPeliculaGenero([FromBody] PeliculaGenero item)
    {
        try
        {
            _db.PeliculaGeneros.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        catch (Exception ex) { return BadRequest(new { mensaje = ex.GetBaseException().Message }); }
    }

    [HttpDelete("pelicula-generos/{idPelicula}/{idGenero}")]
    public async Task<IActionResult> DeletePeliculaGenero(string idPelicula, string idGenero)
    {
        var item = await _db.PeliculaGeneros.FindAsync(idPelicula, idGenero);
        if (item is null) return NotFound();
        _db.PeliculaGeneros.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("evento-expositores")]
    public async Task<ActionResult<List<EventoExpositor>>> GetEventoExpositores()
        => await _db.EventoExpositores.AsNoTracking().ToListAsync();

    [HttpPost("evento-expositores")]
    public async Task<IActionResult> AddEventoExpositor([FromBody] EventoExpositor item)
    {
        try
        {
            _db.EventoExpositores.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        catch (Exception ex) { return BadRequest(new { mensaje = ex.GetBaseException().Message }); }
    }

    [HttpDelete("evento-expositores/{idEvento}/{idExpositor}")]
    public async Task<IActionResult> DeleteEventoExpositor(string idEvento, string idExpositor)
    {
        var item = await _db.EventoExpositores.FindAsync(idEvento, idExpositor);
        if (item is null) return NotFound();
        _db.EventoExpositores.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("categoria-jurados")]
    public async Task<ActionResult<List<CategoriaJurado>>> GetCategoriaJurados()
        => await _db.CategoriaJurados.AsNoTracking().ToListAsync();

    [HttpPost("categoria-jurados")]
    public async Task<IActionResult> AddCategoriaJurado([FromBody] CategoriaJurado item)
    {
        try
        {
            _db.CategoriaJurados.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        catch (Exception ex) { return BadRequest(new { mensaje = ex.GetBaseException().Message }); }
    }

    [HttpDelete("categoria-jurados/{idCategoria}/{idJurado}")]
    public async Task<IActionResult> DeleteCategoriaJurado(string idCategoria, string idJurado)
    {
        var item = await _db.CategoriaJurados.FindAsync(idCategoria, idJurado);
        if (item is null) return NotFound();
        _db.CategoriaJurados.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("abono-proyecciones")]
    public async Task<ActionResult<List<AbonoProyeccion>>> GetAbonoProyecciones()
        => await _db.AbonoProyecciones.AsNoTracking().ToListAsync();

    [HttpPost("abono-proyecciones")]
    public async Task<IActionResult> AddAbonoProyeccion([FromBody] AbonoProyeccion item)
    {
        try
        {
            _db.AbonoProyecciones.Add(item);
            await _db.SaveChangesAsync();
            return Ok(item);
        }
        catch (Exception ex) { return BadRequest(new { mensaje = ex.GetBaseException().Message }); }
    }

    [HttpDelete("abono-proyecciones/{idAbono}/{idProyeccion}")]
    public async Task<IActionResult> DeleteAbonoProyeccion(string idAbono, string idProyeccion)
    {
        var item = await _db.AbonoProyecciones.FindAsync(idAbono, idProyeccion);
        if (item is null) return NotFound();
        _db.AbonoProyecciones.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
