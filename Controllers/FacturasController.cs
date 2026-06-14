using FestCineApi.Data;
using FestCineApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestCineApi.Controllers;

[ApiController]
[Route("api/facturas")]
public class FacturasController : CrudController<Factura>
{
    public FacturasController(FestCineDbContext db) : base(db) { }
}
