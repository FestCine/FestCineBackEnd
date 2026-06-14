using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/categorias-competicion")]
public class CategoriasCompeticionController : CrudController<CategoriaCompeticion>
{
    public CategoriasCompeticionController(FestCineDbContext db) : base(db) { }
}
