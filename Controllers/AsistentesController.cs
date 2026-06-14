using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/asistentes")]
public class AsistentesController : CrudController<Asistente>
{
    public AsistentesController(FestCineDbContext db) : base(db) { }
}
