using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/jurados")]
public class JuradosController : CrudController<Jurado>
{
    public JuradosController(FestCineDbContext db) : base(db) { }
}
