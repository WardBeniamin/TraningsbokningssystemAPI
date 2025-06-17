using TraningsbokningssystemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using TraningsbokningssystemAPI.Data;
using TraningsbokningssystemAPI.Models;

namespace TraningsbokningssystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TräningspassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IVäderService _väderService;

        public TräningspassController(ApplicationDbContext context, IVäderService väderService)
        {
            _context = context;
            _väderService = väderService;
        }


        // GET: api/Träningspass?typ=Yoga&sort=asc
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? typ, [FromQuery] string? sort)
        {
            var query = _context.Träningspass.AsQueryable();

            if (!string.IsNullOrEmpty(typ))
                query = query.Where(p => p.Typ.ToLower() == typ.ToLower());

            if (sort == "asc")
                query = query.OrderBy(p => p.StartTid);
            else if (sort == "desc")
                query = query.OrderByDescending(p => p.StartTid);

            return Ok(query.ToList());
        }

        [HttpGet("väder")]
        public async Task<IActionResult> HämtaVäder([FromQuery] DateTime datum)
        {
            var data = await _väderService.HämtaVäderAsync(datum);
            return Ok(data);
        }

        // PUT: api/Träningspass/1
        [HttpPut("{id}")]
        public IActionResult Uppdatera(int id, [FromBody] TräningsPass uppdateratPass)
        {
            var befintligtPass = _context.Träningspass.FirstOrDefault(p => p.Id == id);

            if (befintligtPass == null)
                return NotFound();

            befintligtPass.Typ = uppdateratPass.Typ;
            befintligtPass.StartTid = uppdateratPass.StartTid;

            _context.SaveChanges();
            return NoContent();
        }
        // DELETE: api/Träningspass/1
        [HttpDelete("{id}")]
        public IActionResult Radera(int id)
        {
            var pass = _context.Träningspass.FirstOrDefault(p => p.Id == id);

            if (pass == null)
                return NotFound();

            _context.Träningspass.Remove(pass);
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Träningspass
        [HttpPost]
        public IActionResult Skapa([FromBody] TräningsPass pass)
        {
            _context.Träningspass.Add(pass);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = pass.Id }, pass);
        }
    }
}
