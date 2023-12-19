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
    public class DeliveryOrdersController : ControllerBase
    {
        private readonly DoubleBContext _context;

        public DeliveryOrdersController(DoubleBContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryOrder>>> GetDeliveryOrders()
        {
            return await _context.DeliveryOrders.ToListAsync();
        }

        // GET: api/DeliveryOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryOrder>> GetDeliveryOrder(int id)
        {
            var deliveryOrder = await _context.DeliveryOrders.FindAsync(id);

            if (deliveryOrder == null)
            {
                return NotFound();
            }

            return deliveryOrder;
        }

        // PUT: api/DeliveryOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeliveryOrder(int id, DeliveryOrder deliveryOrder)
        {
            if (id != deliveryOrder.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(deliveryOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryOrderExists(id))
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

        // POST: api/DeliveryOrders
        [HttpPost]
        public async Task<ActionResult<DeliveryOrder>> CreateDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            _context.DeliveryOrders.Add(deliveryOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeliveryOrder), new { id = deliveryOrder.Orderid }, deliveryOrder);
        }

        // DELETE: api/DeliveryOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryOrder(int id)
        {
            var deliveryOrder = await _context.DeliveryOrders.FindAsync(id);
            if (deliveryOrder == null)
            {
                return NotFound();
            }

            _context.DeliveryOrders.Remove(deliveryOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryOrderExists(int id)
        {
            return _context.DeliveryOrders.Any(e => e.Orderid == id);
        }
    }
}
