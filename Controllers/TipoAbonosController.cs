using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/tipo-abonos")]
public class TipoAbonosController : CrudController<TipoAbono>
{
    public TipoAbonosController(FestCineDbContext db) : base(db) { }
}
