using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/patrocinios")]
public class PatrociniosController : CrudController<Patrocinio>
{
    public PatrociniosController(FestCineDbContext db) : base(db) { }
}
