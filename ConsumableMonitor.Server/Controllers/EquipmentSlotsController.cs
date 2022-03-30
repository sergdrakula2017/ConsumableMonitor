#nullable disable
using ConsumableMonitor.Data;
using ConsumableMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentSlotsController : ControllerBase
{
    private readonly ConsumableMonitorDataContext _context;

    public EquipmentSlotsController(ConsumableMonitorDataContext context) => _context = context;

    // GET: api/EquipmentSlots
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipmentSlot>>> GetEquipmentSlots() => await _context.EquipmentSlots.ToListAsync();

    // GET: api/EquipmentSlots/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EquipmentSlot>> GetEquipmentSlot(int id)
    {
        EquipmentSlot equipmentSlot = await _context.EquipmentSlots.FindAsync(id);

        if (equipmentSlot == null) return NotFound();

        return equipmentSlot;
    }

    // PUT: api/EquipmentSlots/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEquipmentSlot(int id, EquipmentSlot equipmentSlot)
    {
        if (id != equipmentSlot.EquipmentId) return BadRequest();

        _context.Entry(equipmentSlot).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EquipmentSlotExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/EquipmentSlots
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EquipmentSlot>> PostEquipmentSlot(EquipmentSlot equipmentSlot)
    {
        _context.EquipmentSlots.Add(equipmentSlot);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (EquipmentSlotExists(equipmentSlot.EquipmentId))
                return Conflict();
            throw;
        }

        return CreatedAtAction("GetEquipmentSlot", new {id = equipmentSlot.EquipmentId}, equipmentSlot);
    }

    // DELETE: api/EquipmentSlots/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEquipmentSlot(int id)
    {
        EquipmentSlot equipmentSlot = await _context.EquipmentSlots.FindAsync(id);
        if (equipmentSlot == null) return NotFound();

        _context.EquipmentSlots.Remove(equipmentSlot);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EquipmentSlotExists(int id)
    {
        return _context.EquipmentSlots.Any(e => e.EquipmentId == id);
    }
}