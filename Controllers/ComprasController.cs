using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/compras")]
public class ComprasController : CrudController<Compra>
{
    public ComprasController(FestCineDbContext db) : base(db) { }
}
