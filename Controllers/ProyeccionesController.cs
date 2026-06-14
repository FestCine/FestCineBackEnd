using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/proyecciones")]
public class ProyeccionesController : CrudController<Proyeccion>
{
    public ProyeccionesController(FestCineDbContext db) : base(db) { }
}
