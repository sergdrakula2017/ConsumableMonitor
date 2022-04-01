#nullable disable
using ConsumableMonitor.Data;
using ConsumableMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentSlotDescriptorsController : ControllerBase
{
    private readonly ConsumableMonitorDataContext _context;

    public EquipmentSlotDescriptorsController(ConsumableMonitorDataContext context) => _context = context;

    // GET: api/EquipmentSlotDescriptors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipmentSlotDescriptor>>> GetEquipmentSlotDescriptors() => await _context.EquipmentSlotDescriptors.ToListAsync();

    // GET: api/EquipmentSlotDescriptors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EquipmentSlotDescriptor>> GetEquipmentSlotDescriptor(int id)
    {
        EquipmentSlotDescriptor equipmentSlotDescriptor = await _context.EquipmentSlotDescriptors.FindAsync(id);

        if (equipmentSlotDescriptor == null) return NotFound();

        return equipmentSlotDescriptor;
    }

    // PUT: api/EquipmentSlotDescriptors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEquipmentSlotDescriptor(int id, EquipmentSlotDescriptor equipmentSlotDescriptor)
    {
        if (id != equipmentSlotDescriptor.ModelId) return BadRequest();

        _context.Entry(equipmentSlotDescriptor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EquipmentSlotDescriptorExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/EquipmentSlotDescriptors
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EquipmentSlotDescriptor>> PostEquipmentSlotDescriptor(EquipmentSlotDescriptor equipmentSlotDescriptor)
    {
        _context.EquipmentSlotDescriptors.Add(equipmentSlotDescriptor);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (EquipmentSlotDescriptorExists(equipmentSlotDescriptor.ModelId))
                return Conflict();
            throw;
        }

        return CreatedAtAction("GetEquipmentSlotDescriptor", new {id = equipmentSlotDescriptor.ModelId}, equipmentSlotDescriptor);
    }

    // DELETE: api/EquipmentSlotDescriptors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEquipmentSlotDescriptor(int id)
    {
        EquipmentSlotDescriptor equipmentSlotDescriptor = await _context.EquipmentSlotDescriptors.FindAsync(id);
        if (equipmentSlotDescriptor == null) return NotFound();

        _context.EquipmentSlotDescriptors.Remove(equipmentSlotDescriptor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EquipmentSlotDescriptorExists(int id)
    {
        return _context.EquipmentSlotDescriptors.Any(e => e.ModelId == id);
    }
}