using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DoubleBack.Models;
using DoubleBack.Data;
using Microsoft.EntityFrameworkCore;

namespace DoubleBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly DoubleBContext _context;

        public SalesController(DoubleBContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetSales()
        {
            return _context.Sales.ToList();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public ActionResult<Sale> GetSale(int id)
        {
            var sale = _context.Sales.Find(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, Sale sale)
        {
            if (id != sale.Saleid)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Sales
        [HttpPost]
        public ActionResult<Sale> CreateSale(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSale), new { id = sale.Saleid }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var sale = _context.Sales.Find(id);

            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
