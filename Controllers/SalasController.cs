using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/salas")]
public class SalasController : CrudController<Sala>
{
    public SalasController(FestCineDbContext db) : base(db) { }
}
