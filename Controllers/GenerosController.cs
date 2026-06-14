using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/generos")]
public class GenerosController : CrudController<Genero>
{
    public GenerosController(FestCineDbContext db) : base(db) { }
}
