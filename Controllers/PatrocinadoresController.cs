using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/patrocinadores")]
public class PatrocinadoresController : CrudController<Patrocinador>
{
    public PatrocinadoresController(FestCineDbContext db) : base(db) { }
}
