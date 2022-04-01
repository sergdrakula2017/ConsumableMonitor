#nullable disable
using ConsumableMonitor.Data;
using ConsumableMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsumablesController : ControllerBase
{
    private readonly ConsumableMonitorDataContext _context;

    public ConsumablesController(ConsumableMonitorDataContext context) => _context = context;

    // GET: api/Consumables
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consumable>>> GetConsumables() => await _context.Consumables.ToListAsync();

    // GET: api/Consumables/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Consumable>> GetConsumable(int id)
    {
        Consumable consumable = await _context.Consumables.FindAsync(id);

        if (consumable == null) return NotFound();

        return consumable;
    }

    // PUT: api/Consumables/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutConsumable(int id, Consumable consumable)
    {
        if (id != consumable.Id) return BadRequest();

        _context.Entry(consumable).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsumableExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Consumables
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Consumable>> PostConsumable(Consumable consumable)
    {
        _context.Consumables.Add(consumable);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsumable", new {id = consumable.Id}, consumable);
    }

    // DELETE: api/Consumables/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsumable(int id)
    {
        Consumable consumable = await _context.Consumables.FindAsync(id);
        if (consumable == null) return NotFound();

        _context.Consumables.Remove(consumable);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsumableExists(int id)
    {
        return _context.Consumables.Any(e => e.Id == id);
    }
}