using Microsoft.AspNetCore.Mvc;
using TraningsbokningssystemAPI.Data;
using TraningsbokningssystemAPI.Models;

namespace TraningsbokningssystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KundController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KundController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Kund
        [HttpGet]
        public IActionResult GetAlla()
        {
            var kunder = _context.Kunder.ToList();
            return Ok(kunder);
        }

        // PUT: api/Kund/1
        [HttpPut("{id}")]
        public IActionResult Uppdatera(int id, [FromBody] Kund uppdateradKund)
        {
            var befintligKund = _context.Kunder.FirstOrDefault(k => k.Id == id);

            if (befintligKund == null)
                return NotFound();

            befintligKund.Namn = uppdateradKund.Namn;

            _context.SaveChanges();
            return NoContent(); // 204
        }
        // DELETE: api/Kund/1
        [HttpDelete("{id}")]
        public IActionResult Radera(int id)
        {
            var kund = _context.Kunder.FirstOrDefault(k => k.Id == id);

            if (kund == null)
                return NotFound();

            _context.Kunder.Remove(kund);
            _context.SaveChanges();

            return NoContent(); // 204
        }


        // POST: api/Kund
        [HttpPost]
        public IActionResult Skapa([FromBody] Kund nyKund)
        {
            _context.Kunder.Add(nyKund);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAlla), new { id = nyKund.Id }, nyKund);
        }
    }
}
