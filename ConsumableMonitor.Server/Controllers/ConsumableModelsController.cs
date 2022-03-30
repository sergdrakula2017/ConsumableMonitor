#nullable disable
using ConsumableMonitor.Data;
using ConsumableMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsumableModelsController : ControllerBase
{
    private readonly ConsumableMonitorDataContext _context;

    public ConsumableModelsController(ConsumableMonitorDataContext context) => _context = context;

    // GET: api/ConsumableModels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsumableModel>>> GetConsumableModels() => await _context.ConsumableModels.ToListAsync();

    // GET: api/ConsumableModels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ConsumableModel>> GetConsumableModel(int id)
    {
        ConsumableModel consumableModel = await _context.ConsumableModels.FindAsync(id);

        if (consumableModel == null) return NotFound();

        return consumableModel;
    }

    // PUT: api/ConsumableModels/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutConsumableModel(int id, ConsumableModel consumableModel)
    {
        if (id != consumableModel.Id) return BadRequest();

        _context.Entry(consumableModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConsumableModelExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/ConsumableModels
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ConsumableModel>> PostConsumableModel(ConsumableModel consumableModel)
    {
        _context.ConsumableModels.Add(consumableModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConsumableModel", new {id = consumableModel.Id}, consumableModel);
    }

    // DELETE: api/ConsumableModels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsumableModel(int id)
    {
        ConsumableModel consumableModel = await _context.ConsumableModels.FindAsync(id);
        if (consumableModel == null) return NotFound();

        _context.ConsumableModels.Remove(consumableModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConsumableModelExists(int id)
    {
        return _context.ConsumableModels.Any(e => e.Id == id);
    }
}