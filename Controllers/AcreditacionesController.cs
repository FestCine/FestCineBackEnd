using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/acreditaciones")]
public class AcreditacionesController : CrudController<Acreditacion>
{
    public AcreditacionesController(FestCineDbContext db) : base(db) { }
}
