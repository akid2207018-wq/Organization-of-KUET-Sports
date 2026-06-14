using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OksApi.Models;

namespace OksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixturesController : ControllerBase
    {
        private readonly OksContext _context;

        public FixturesController(OksContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fixture>>> GetFixtures()
        {
            return await _context.Fixtures.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Fixture>> PostFixture(Fixture fixture)
        {
            _context.Fixtures.Add(fixture);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFixtures), new { id = fixture.Id }, fixture);
        }
    }
}
