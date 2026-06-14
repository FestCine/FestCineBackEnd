using FestCineApi.Data;
using FestCineApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/catalogos")]
public class CatalogosController : ControllerBase
{
    private readonly FestCineDbContext _db;

    public CatalogosController(FestCineDbContext db)
    {
        _db = db;
    }

    [HttpGet("peliculas/{idEdicion}")]
    public async Task<IActionResult> PeliculasPorEdicion(string idEdicion)
    {
        var data = await
            (from pe in _db.PeliculaEdiciones.AsNoTracking()
             join p in _db.Peliculas.AsNoTracking() on pe.IdPelicula equals p.IdPelicula
             where pe.IdEdicion == idEdicion
             orderby p.Titulo
             select new PeliculaCatalogoDto
             {
                 IdPelicula = p.IdPelicula,
                 IdPeliculaEdicion = pe.IdPeliculaEdicion,
                 Titulo = p.Titulo,
                 Duracion = p.Duracion,
                 EstadoFestival = pe.EstadoFestival
             }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("proyecciones/{idEdicion}")]
    public async Task<IActionResult> ProyeccionesPorEdicion(string idEdicion)
    {
        var data = await
            (from pr in _db.Proyecciones.AsNoTracking()
             join pe in _db.PeliculaEdiciones.AsNoTracking() on pr.IdPeliculaEdicion equals pe.IdPeliculaEdicion
             join p in _db.Peliculas.AsNoTracking() on pe.IdPelicula equals p.IdPelicula
             join s in _db.Salas.AsNoTracking() on pr.IdSala equals s.IdSala
             where pe.IdEdicion == idEdicion
             orderby pr.FechaHoraInicio
             select new ProyeccionCatalogoDto
             {
                 IdProyeccion = pr.IdProyeccion,
                 FechaHoraInicio = pr.FechaHoraInicio,
                 TieneQA = pr.TieneQA,
                 IdSala = s.IdSala,
                 NombreSala = s.NombreSala,
                 Capacidad = s.Capacidad,
                 TituloPelicula = p.Titulo
             }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("asistentes/{idEdicion}")]
    public async Task<IActionResult> AsistentesPorEdicion(string idEdicion)
    {
        var data = await
            (from a in _db.Asistentes.AsNoTracking()
             join p in _db.Personas.AsNoTracking() on a.IdPersona equals p.IdPersona
             where a.IdEdicion == idEdicion
             orderby p.Apellido, p.Nombre
             select new AsistenteCatalogoDto
             {
                 IdAsistente = a.IdAsistente,
                 NombreCompleto = p.Nombre + " " + p.Apellido,
                 Correo = p.Correo
             }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("tarifas")]
    public async Task<IActionResult> Tarifas()
        => Ok(await _db.Tarifas.AsNoTracking().OrderBy(t => t.TipoTarifa).ToListAsync());

    [HttpGet("salas")]
    public async Task<IActionResult> Salas()
        => Ok(await _db.Salas.AsNoTracking().OrderBy(s => s.IdSede).ThenBy(s => s.NroSala).ToListAsync());

    [HttpGet("tipo-abonos")]
    public async Task<IActionResult> TipoAbonos()
        => Ok(await _db.TipoAbonos.AsNoTracking().OrderBy(t => t.NombreTipoAbono).ToListAsync());

    [HttpGet("generos")]
    public async Task<IActionResult> Generos()
        => Ok(await _db.Generos.AsNoTracking().OrderBy(g => g.NombreGenero).ToListAsync());

    [HttpGet("categorias/{idEdicion}")]
    public async Task<IActionResult> CategoriasPorEdicion(string idEdicion)
        => Ok(await _db.CategoriasCompeticion.AsNoTracking()
            .Where(c => c.IdEdicion == idEdicion)
            .OrderBy(c => c.NombreCategoria)
            .ToListAsync());

    [HttpGet("sedes/{idEdicion}")]
    public async Task<IActionResult> SedesPorEdicion(string idEdicion)
    {
        var data = await
            (from sx in _db.SedeEdiciones.AsNoTracking()
             join s in _db.Sedes.AsNoTracking() on sx.IdSede equals s.IdSede
             where sx.IdEdicion == idEdicion
             orderby s.NombreSede
             select s).ToListAsync();

        return Ok(data);
    }

    [HttpGet("salas/{idEdicion}")]
    public async Task<IActionResult> SalasPorEdicion(string idEdicion)
    {
        var data = await
            (from sx in _db.SedeEdiciones.AsNoTracking()
             join s in _db.Sedes.AsNoTracking() on sx.IdSede equals s.IdSede
             join sa in _db.Salas.AsNoTracking() on s.IdSede equals sa.IdSede
             where sx.IdEdicion == idEdicion
             orderby s.NombreSede, sa.NroSala
             select sa).ToListAsync();

        return Ok(data);
    }

    [HttpGet("eventos/{idEdicion}")]
    public async Task<IActionResult> EventosPorEdicion(string idEdicion)
        => Ok(await _db.EventosParalelos.AsNoTracking()
            .Where(e => e.IdEdicion == idEdicion)
            .OrderBy(e => e.FechaHoraInicio)
            .ToListAsync());

}
