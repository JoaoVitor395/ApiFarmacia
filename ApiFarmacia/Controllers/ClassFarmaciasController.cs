using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiFarmacia.Data;
using ApiFarmacia.Models;

namespace ApiFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassFarmaciasController : ControllerBase
    {
        private readonly ApiFarmaciaContext _context;

        public ClassFarmaciasController(ApiFarmaciaContext context)
        {
            _context = context;
        }

        // GET: api/ClassFarmacias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassFarmacia>>> GetClassFarmacia()
        {
          if (_context.ClassFarmacia == null)
          {
              return NotFound();
          }
            return await _context.ClassFarmacia.ToListAsync();
        }

        // GET: api/ClassFarmacias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassFarmacia>> GetClassFarmacia(int id)
        {
          if (_context.ClassFarmacia == null)
          {
              return NotFound();
          }
            var classFarmacia = await _context.ClassFarmacia.FindAsync(id);

            if (classFarmacia == null)
            {
                return NotFound();
            }

            return classFarmacia;
        }

        // PUT: api/ClassFarmacias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassFarmacia(int id, ClassFarmacia classFarmacia)
        {
            if (id != classFarmacia.id)
            {
                return BadRequest();
            }

            _context.Entry(classFarmacia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassFarmaciaExists(id))
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

        // POST: api/ClassFarmacias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassFarmacia>> PostClassFarmacia(ClassFarmacia classFarmacia)
        {
          if (_context.ClassFarmacia == null)
          {
              return Problem("Entity set 'ApiFarmaciaContext.ClassFarmacia'  is null.");
          }
            _context.ClassFarmacia.Add(classFarmacia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassFarmacia", new { id = classFarmacia.id }, classFarmacia);
        }

        // DELETE: api/ClassFarmacias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassFarmacia(int id)
        {
            if (_context.ClassFarmacia == null)
            {
                return NotFound();
            }
            var classFarmacia = await _context.ClassFarmacia.FindAsync(id);
            if (classFarmacia == null)
            {
                return NotFound();
            }

            _context.ClassFarmacia.Remove(classFarmacia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassFarmaciaExists(int id)
        {
            return (_context.ClassFarmacia?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
