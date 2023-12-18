using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DoubleBack.Models;
using DoubleBack.Data;
using DoubleBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DoubleBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly DoubleBContext _context;

        public ShopController(DoubleBContext context)
        {
            _context = context;
        }

        // GET: api/Shop
        [HttpGet]
        public ActionResult<IEnumerable<Coffeeshop>> GetShops()
        {
            return _context.Coffeeshops.ToList();
        }

        // GET: api/Shop/5
        [HttpGet("{id}")]
        public ActionResult<Coffeeshop> GetShop(int id)
        {
            var shop = _context.Coffeeshops.Find(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }

        // PUT: api/Shop/5
        [HttpPut("{id}")]
        public IActionResult UpdateShop(int id, Coffeeshop shop)
        {
            if (id != shop.Shopid)
            {
                return BadRequest();
            }

            _context.Entry(shop).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Shop
        [HttpPost]
        public ActionResult<Coffeeshop> CreateShop(Coffeeshop shop)
        {
            _context.Coffeeshops.Add(shop);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetShop), new { id = shop.Shopid }, shop);
        }

        // DELETE: api/Shop/5
        [HttpDelete("{id}")]
        public IActionResult DeleteShop(int id)
        {
            var shop = _context.Coffeeshops.Find(id);

            if (shop == null)
            {
                return NotFound();
            }

            _context.Coffeeshops.Remove(shop);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
