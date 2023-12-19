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
    public class DeliveryCompanyController : ControllerBase
    {
        private readonly DoubleBContext _context;

        public DeliveryCompanyController(DoubleBContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryCompany>>> GetDeliveryCompanies()
        {
            return await _context.DeliveryCompanies.ToListAsync();
        }

        // GET: api/DeliveryCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryCompany>> GetDeliveryCompany(int id)
        {
            var deliveryCompany = await _context.DeliveryCompanies.FindAsync(id);

            if (deliveryCompany == null)
            {
                return NotFound();
            }

            return deliveryCompany;
        }

        // PUT: api/DeliveryCompany/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeliveryCompany(int id, DeliveryCompany deliveryCompany)
        {
            if (id != deliveryCompany.Companyid)
            {
                return BadRequest();
            }

            _context.Entry(deliveryCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryCompanyExists(id))
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

        // POST: api/DeliveryCompany
        [HttpPost]
        public async Task<ActionResult<DeliveryCompany>> CreateDeliveryCompany(DeliveryCompany deliveryCompany)
        {
            _context.DeliveryCompanies.Add(deliveryCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeliveryCompany), new { id = deliveryCompany.Companyid }, deliveryCompany);
        }

        // DELETE: api/DeliveryCompany/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryCompany(int id)
        {
            var deliveryCompany = await _context.DeliveryCompanies.FindAsync(id);
            if (deliveryCompany == null)
            {
                return NotFound();
            }

            _context.DeliveryCompanies.Remove(deliveryCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryCompanyExists(int id)
        {
            return _context.DeliveryCompanies.Any(e => e.Companyid == id);
        }
    }
}
