using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/tipo-acreditaciones")]
public class TipoAcreditacionesController : CrudController<TipoAcreditacion>
{
    public TipoAcreditacionesController(FestCineDbContext db) : base(db) { }
}
