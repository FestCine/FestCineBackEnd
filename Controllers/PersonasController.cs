using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/personas")]
public class PersonasController : CrudController<Persona>
{
    public PersonasController(FestCineDbContext db) : base(db) { }
}
