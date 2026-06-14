using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/peliculas")]
public class PeliculasController : CrudController<Pelicula>
{
    public PeliculasController(FestCineDbContext db) : base(db) { }
}
