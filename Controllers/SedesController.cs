using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/sedes")]
public class SedesController : CrudController<Sede>
{
    public SedesController(FestCineDbContext db) : base(db) { }
}
