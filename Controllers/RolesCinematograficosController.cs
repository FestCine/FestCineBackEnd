using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/roles-cinematograficos")]
public class RolesCinematograficosController : CrudController<RolCinematografico>
{
    public RolesCinematograficosController(FestCineDbContext db) : base(db) { }
}
