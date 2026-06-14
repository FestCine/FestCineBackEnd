using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/asistencias-proyeccion")]
public class AsistenciasProyeccionController : CrudController<AsistenciaProyeccion>
{
    public AsistenciasProyeccionController(FestCineDbContext db) : base(db) { }
}
