using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/eventos-paralelos")]
public class EventosParalelosController : CrudController<EventoParalelo>
{
    public EventosParalelosController(FestCineDbContext db) : base(db) { }
}
