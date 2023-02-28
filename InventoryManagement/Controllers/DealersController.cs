using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly Context _context;

        public DealersController(Context context)
        {
            _context = context;
        }

        // GET: api/Dealers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dealer>>> GetDealers()
        {
          if (_context.Dealers == null)
          {
              return NotFound();
          }
            return await _context.Dealers.Include(d => d.Products).ToListAsync();
        }

        // GET: api/Dealers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dealer>> GetDealer(long id)
        {
          if (_context.Dealers == null)
          {
              return NotFound();
          }
            var dealer = await _context.Dealers.FindAsync(id);

            if (dealer == null)
            {
                return NotFound();
            }

            return dealer;
        }

        // PUT: api/Dealers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealer(long id, Dealer dealer)
        {
            if (id != dealer.ID)
            {
                return BadRequest();
            }

            _context.Entry(dealer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealerExists(id))
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

        // POST: api/Dealers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dealer>> PostDealer(Dealer dealer)
        {
          if (_context.Dealers == null)
          {
              return Problem("Entity set 'Context.Dealers'  is null.");
          }
            _context.Dealers.Add(dealer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDealer", new { id = dealer.ID }, dealer);
        }

        [HttpPost("{id}/add_product")]
        public async Task<ActionResult<Dealer>> AddProduct(long id,Product product)
        {
            if (_context.Dealers == null)
            {
                return Problem("Entity set 'Context.Dealers'  is null.");
            }
            var dealer = await _context.Dealers.FindAsync(id);
            dealer.Products.Append(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Dealers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealer(long id)
        {
            if (_context.Dealers == null)
            {
                return NotFound();
            }
            var dealer = await _context.Dealers.FindAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }

            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DealerExists(long id)
        {
            return (_context.Dealers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
