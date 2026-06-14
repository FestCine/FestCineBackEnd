using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/expositores")]
public class ExpositoresController : CrudController<Expositor>
{
    public ExpositoresController(FestCineDbContext db) : base(db) { }
}
