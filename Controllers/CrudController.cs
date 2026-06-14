using FestCineApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Controllers;

[ApiController]
public abstract class CrudController<TEntity> : ControllerBase where TEntity : class
{
    protected readonly FestCineDbContext Db;

    protected CrudController(FestCineDbContext db)
    {
        Db = db;
    }

    [HttpGet]
    public virtual async Task<ActionResult<List<TEntity>>> GetAll()
    {
        return await Db.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity>> GetById(string id)
    {
        var entity = await Db.Set<TEntity>().FindAsync(id);
        return entity is null ? NotFound() : entity;
    }

    [HttpPost]
    public virtual async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity)
    {
        try
        {
            Db.Set<TEntity>().Add(entity);
            await Db.SaveChangesAsync();
            return Ok(entity);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Update(string id, [FromBody] TEntity entity)
    {
        try
        {
            var existing = await Db.Set<TEntity>().FindAsync(id);
            if (existing is null) return NotFound();

            Db.Entry(existing).CurrentValues.SetValues(entity);
            await Db.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(string id)
    {
        try
        {
            var entity = await Db.Set<TEntity>().FindAsync(id);
            if (entity is null) return NotFound();

            Db.Set<TEntity>().Remove(entity);
            await Db.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.GetBaseException().Message });
        }
    }
}
