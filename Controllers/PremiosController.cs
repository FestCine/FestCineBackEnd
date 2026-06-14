using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/premios")]
public class PremiosController : CrudController<Premio>
{
    public PremiosController(FestCineDbContext db) : base(db) { }
}
