using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/traslados")]
public class TrasladosController : CrudController<Traslado>
{
    public TrasladosController(FestCineDbContext db) : base(db) { }
}
