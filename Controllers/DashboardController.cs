using FestCineApi.Data;
using FestCineApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly FestCineDbContext _db;

    public DashboardController(FestCineDbContext db)
    {
        _db = db;
    }

    [HttpGet("{idEdicion}")]
    public async Task<ActionResult<DashboardDto>> Get(string idEdicion)
    {
        var peliculas = await _db.PeliculaEdiciones.CountAsync(x => x.IdEdicion == idEdicion);

        var proyecciones = await
            (from pr in _db.Proyecciones
             join pe in _db.PeliculaEdiciones on pr.IdPeliculaEdicion equals pe.IdPeliculaEdicion
             where pe.IdEdicion == idEdicion
             select pr.IdProyeccion).CountAsync();

        var asistentes = await _db.Asistentes.CountAsync(x => x.IdEdicion == idEdicion);

        var entradas = await
            (from ei in _db.EntradasIndividuales
             join c in _db.Compras on ei.IdCompra equals c.IdCompra
             where c.IdEdicion == idEdicion
             select ei.IdEntrada).CountAsync();

        var abonos = await
            (from a in _db.Abonos
             join c in _db.Compras on a.IdCompra equals c.IdCompra
             where c.IdEdicion == idEdicion
             select a.IdAbono).CountAsync();

        var totalEntradas = await
            (from ei in _db.EntradasIndividuales
             join c in _db.Compras on ei.IdCompra equals c.IdCompra
             where c.IdEdicion == idEdicion
             select ei.PrecioAplicado).SumAsync();

        var totalAbonos = await
            (from a in _db.Abonos
             join c in _db.Compras on a.IdCompra equals c.IdCompra
             where c.IdEdicion == idEdicion
             select a.PrecioAplicado).SumAsync();

        return Ok(new DashboardDto
        {
            IdEdicion = idEdicion,
            Peliculas = peliculas,
            Proyecciones = proyecciones,
            Asistentes = asistentes,
            EntradasVendidas = entradas,
            AbonosVendidos = abonos,
            TotalRecaudado = totalEntradas + totalAbonos
        });
    }
}
