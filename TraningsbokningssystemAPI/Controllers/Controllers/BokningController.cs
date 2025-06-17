using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraningsbokningssystemAPI.Data;
using TraningsbokningssystemAPI.Models;

namespace TraningsbokningssystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BokningController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BokningController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bokning
        [HttpGet]
        public IActionResult GetAlla()
        {
            var bokningar = _context.Bokningar
                .Include(b => b.Kund)
                .Include(b => b.Pass)
                .ToList();

            return Ok(bokningar);
        }

        // POST: api/Bokning
        [HttpPost]
        public IActionResult Skapa([FromBody] Bokning bokning)
        {
            _context.Bokningar.Add(bokning);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAlla), new { id = bokning.Id }, bokning);
        }
    }
}
