using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/alojamientos")]
public class AlojamientosController : CrudController<Alojamiento>
{
    public AlojamientosController(FestCineDbContext db) : base(db) { }
}
