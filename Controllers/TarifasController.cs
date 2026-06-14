using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/tarifas")]
public class TarifasController : CrudController<Tarifa>
{
    public TarifasController(FestCineDbContext db) : base(db) { }
}
