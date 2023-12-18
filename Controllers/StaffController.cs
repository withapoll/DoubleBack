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
    public class StaffController : ControllerBase
    {
        private readonly DoubleBContext _context;

        public StaffController(DoubleBContext context)
        {
            _context = context;
        }

        // GET: api/Staff
        [HttpGet]
        public ActionResult<IEnumerable<Human>> GetHumans()
        {
            return _context.Humans.ToList();
        }

        // GET: api/Staff/5
        [HttpGet("{id}")]
        public ActionResult<Human> GetHuman(int id)
        {
            var human = _context.Humans.Find(id);

            if (human == null)
            {
                return NotFound();
            }

            return human;
        }

        // PUT: api/Staff/5
        [HttpPut("{id}")]
        public IActionResult UpdateHuman(int id, Human human)
        {
            if (id != human.Employeeid)
            {
                return BadRequest();
            }

            _context.Entry(human).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Staff
        [HttpPost]
        public ActionResult<Human> CreateHuman(Human human)
        {
            _context.Humans.Add(human);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHuman), new { id = human.Employeeid }, human);
        }

        // DELETE: api/Staff/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHuman(int id)
        {
            var human = _context.Humans.Find(id);

            if (human == null)
            {
                return NotFound();
            }

            _context.Humans.Remove(human);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
