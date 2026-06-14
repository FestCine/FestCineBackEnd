using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/evaluaciones")]
public class EvaluacionesController : CrudController<Evaluacion>
{
    public EvaluacionesController(FestCineDbContext db) : base(db) { }
}
