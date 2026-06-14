using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/personal-cinematografico")]
public class PersonalCinematograficoController : CrudController<PersonalCinematografico>
{
    public PersonalCinematograficoController(FestCineDbContext db) : base(db) { }
}
