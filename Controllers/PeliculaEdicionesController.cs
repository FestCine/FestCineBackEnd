using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/pelicula-ediciones")]
public class PeliculaEdicionesController : CrudController<PeliculaEdicion>
{
    public PeliculaEdicionesController(FestCineDbContext db) : base(db) { }
}
