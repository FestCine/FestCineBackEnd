using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/entradas-individuales")]
public class EntradasIndividualesController : CrudController<EntradaIndividual>
{
    public EntradasIndividualesController(FestCineDbContext db) : base(db) { }
}
