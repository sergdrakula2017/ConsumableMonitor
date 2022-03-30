#nullable disable
using ConsumableMonitor.Data;
using ConsumableMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsumableModelFamiliesController : ControllerBase
{
    private readonly ConsumableMonitorDataContext _context;

    public ConsumableModelFamiliesController(ConsumableMonitorDataContext context) => _context = context;

    // GET: api/ConsumableModelFamilies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsumableModelFamily>>> GetConsumableModelsFamilies() => await _context.ConsumableModelsFamilies.ToListAsync();

    // GET: api/ConsumableModelFamilies/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ConsumableModelFamily>> GetConsumableModelFamily(int id)
    {
        ConsumableModelFamily consumableModelFamily = await _context.ConsumableModelsFamilies.FindAsync(id);

        if (consumableModelFamily == null) return NotFound();

        return consumableModelFamily;
    }

    // PUT: api/ConsumableModelFamilies/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutConsumableModelFamily(int id, ConsumableModelFamily consumableModelFamily)
    {
        if (id != consumableModelFamily.Id) return BadRequest();

        _context.Entry(consumableModelFamily).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsumableModelFamilyExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/ConsumableModelFamilies
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ConsumableModelFamily>> PostConsumableModelFamily(ConsumableModelFamily consumableModelFamily)
    {
        _context.ConsumableModelsFamilies.Add(consumableModelFamily);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsumableModelFamily", new {id = consumableModelFamily.Id}, consumableModelFamily);
    }

    // DELETE: api/ConsumableModelFamilies/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsumableModelFamily(int id)
    {
        ConsumableModelFamily consumableModelFamily = await _context.ConsumableModelsFamilies.FindAsync(id);
        if (consumableModelFamily == null) return NotFound();

        _context.ConsumableModelsFamilies.Remove(consumableModelFamily);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsumableModelFamilyExists(int id)
    {
        return _context.ConsumableModelsFamilies.Any(e => e.Id == id);
    }
}