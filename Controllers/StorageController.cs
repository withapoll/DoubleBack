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
    public class StorageController : ControllerBase
    {
        private readonly DoubleBContext _context;

        public StorageController(DoubleBContext context)
        {
            _context = context;
        }

        // GET: api/Storage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeStorage>>> GetCoffeeStorage()
        {
            return await _context.CoffeeStorages.ToListAsync();
        }

        // GET: api/Storage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeStorage>> GetCoffeeStorage(int id)
        {
            var coffeeStorage = await _context.CoffeeStorages.FindAsync(id);

            if (coffeeStorage == null)
            {
                return NotFound();
            }

            return coffeeStorage;
        }

        // PUT: api/Storage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoffeeStorage(int id, CoffeeStorage coffeeStorage)
        {
            if (id != coffeeStorage.Inventoryid)
            {
                return BadRequest();
            }

            _context.Entry(coffeeStorage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeStorageExists(id))
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

        // POST: api/Storage
        [HttpPost]
        public async Task<ActionResult<CoffeeStorage>> CreateCoffeeStorage(CoffeeStorage coffeeStorage)
        {
            _context.CoffeeStorages.Add(coffeeStorage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoffeeStorage), new { id = coffeeStorage.Inventoryid }, coffeeStorage);
        }

        // DELETE: api/Storage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeStorage(int id)
        {
            var coffeeStorage = await _context.CoffeeStorages.FindAsync(id);
            if (coffeeStorage == null)
            {
                return NotFound();
            }

            _context.CoffeeStorages.Remove(coffeeStorage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoffeeStorageExists(int id)
        {
            return _context.CoffeeStorages.Any(e => e.Inventoryid == id);
        }
    }
}
