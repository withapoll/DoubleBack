using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoubleBack.Data;
using DoubleBack.Models;

namespace DoubleBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveDeliveryController : ControllerBase
    {
        private readonly DoubleBContext _context;

        public ActiveDeliveryController(DoubleBContext context)
        {
            _context = context;
        }

        // GET: api/ActiveDelivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveDelivery>>> GetActiveDeliveries()
        {
            return await _context.ActiveDeliveries.ToListAsync();
        }

        // GET: api/ActiveDelivery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveDelivery>> GetActiveDelivery(int id)
        {
            var activeDelivery = await _context.ActiveDeliveries.FindAsync(id);

            if (activeDelivery == null)
            {
                return NotFound();
            }

            return activeDelivery;
        }

        // PUT: api/ActiveDelivery/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActiveDelivery(int id, ActiveDelivery activeDelivery)
        {
            if (id != activeDelivery.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(activeDelivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveDeliveryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActiveDelivery
        [HttpPost]
        public async Task<ActionResult<ActiveDelivery>> CreateActiveDelivery(ActiveDelivery activeDelivery)
        {
            _context.ActiveDeliveries.Add(activeDelivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActiveDelivery), new { id = activeDelivery.Orderid }, activeDelivery);
        }

        // DELETE: api/ActiveDelivery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActiveDelivery(int id)
        {
            var activeDelivery = await _context.ActiveDeliveries.FindAsync(id);
            if (activeDelivery == null)
            {
                return NotFound();
            }

            _context.ActiveDeliveries.Remove(activeDelivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActiveDeliveryExists(int id)
        {
            return _context.ActiveDeliveries.Any(e => e. Orderid == id);
        }
    }
}
