#nullable disable
using ConsumableMonitor.Data;
using ConsumableMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentsController : ControllerBase
{
    private readonly ConsumableMonitorDataContext _context;

    public EquipmentsController(ConsumableMonitorDataContext context) => _context = context;

    // GET: api/Equipments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipments() => await _context.Equipments.ToListAsync();

    // GET: api/Equipments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Equipment>> GetEquipment(int id)
    {
        Equipment equipment = await _context.Equipments.FindAsync(id);

        if (equipment == null) return NotFound();

        return equipment;
    }

    // PUT: api/Equipments/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEquipment(int id, Equipment equipment)
    {
        if (id != equipment.Id) return BadRequest();

        _context.Entry(equipment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EquipmentExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Equipments
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
    {
        _context.Equipments.Add(equipment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEquipment", new {id = equipment.Id}, equipment);
    }

    // DELETE: api/Equipments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEquipment(int id)
    {
        Equipment equipment = await _context.Equipments.FindAsync(id);
        if (equipment == null) return NotFound();

        _context.Equipments.Remove(equipment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EquipmentExists(int id)
    {
        return _context.Equipments.Any(e => e.Id == id);
    }
}