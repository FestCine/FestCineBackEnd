using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/peliculas-compiten")]
public class PeliculasCompitenController : CrudController<PeliculaCompite>
{
    public PeliculasCompitenController(FestCineDbContext db) : base(db) { }
}
