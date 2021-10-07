using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailGUIDsController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailGUIDsController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetailGUIDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetailGUID>>> GetPaymentDetailGUIDs()
        {
            return await _context.PaymentDetailGUIDs.ToListAsync();
        }

        // GET: api/PaymentDetailGUIDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetailGUID>> GetPaymentDetailGUID(Guid id)
        {
            var paymentDetailGUID = await _context.PaymentDetailGUIDs.FindAsync(id);

            if (paymentDetailGUID == null)
            {
                return NotFound();
            }

            return paymentDetailGUID;
        }

        // PUT: api/PaymentDetailGUIDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetailGUID(Guid id, PaymentDetailGUID paymentDetailGUID)
        {
            if (id != paymentDetailGUID.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetailGUID).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailGUIDExists(id))
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

        // POST: api/PaymentDetailGUIDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetailGUID>> PostPaymentDetailGUID(PaymentDetailGUID paymentDetailGUID)
        {
            _context.PaymentDetailGUIDs.Add(paymentDetailGUID);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetailGUID", new { id = paymentDetailGUID.Id }, paymentDetailGUID);
        }

        // DELETE: api/PaymentDetailGUIDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetailGUID(Guid id)
        {
            var paymentDetailGUID = await _context.PaymentDetailGUIDs.FindAsync(id);
            if (paymentDetailGUID == null)
            {
                return NotFound();
            }

            _context.PaymentDetailGUIDs.Remove(paymentDetailGUID);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetailGUIDExists(Guid id)
        {
            return _context.PaymentDetailGUIDs.Any(e => e.Id == id);
        }
    }
}
