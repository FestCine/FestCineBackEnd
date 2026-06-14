using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/abonos-crud")]
public class AbonosCrudController : CrudController<Abono>
{
    public AbonosCrudController(FestCineDbContext db) : base(db) { }
}
