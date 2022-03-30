#nullable disable
using ConsumableMonitor.Data;
using ConsumableMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentModelsController : ControllerBase
{
    private readonly ConsumableMonitorDataContext _context;

    public EquipmentModelsController(ConsumableMonitorDataContext context) => _context = context;

    // GET: api/EquipmentModels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipmentModel>>> GetEquipmentModels() => await _context.EquipmentModels.ToListAsync();

    // GET: api/EquipmentModels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EquipmentModel>> GetEquipmentModel(int id)
    {
        EquipmentModel equipmentModel = await _context.EquipmentModels.FindAsync(id);

        if (equipmentModel == null) return NotFound();

        return equipmentModel;
    }

    // PUT: api/EquipmentModels/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEquipmentModel(int id, EquipmentModel equipmentModel)
    {
        if (id != equipmentModel.Id) return BadRequest();

        _context.Entry(equipmentModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EquipmentModelExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/EquipmentModels
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EquipmentModel>> PostEquipmentModel(EquipmentModel equipmentModel)
    {
        _context.EquipmentModels.Add(equipmentModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEquipmentModel", new {id = equipmentModel.Id}, equipmentModel);
    }

    // DELETE: api/EquipmentModels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEquipmentModel(int id)
    {
        EquipmentModel equipmentModel = await _context.EquipmentModels.FindAsync(id);
        if (equipmentModel == null) return NotFound();

        _context.EquipmentModels.Remove(equipmentModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EquipmentModelExists(int id)
    {
        return _context.EquipmentModels.Any(e => e.Id == id);
    }
}