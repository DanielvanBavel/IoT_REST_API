using IoT_REST_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureContext _context;

        public TemperatureController(TemperatureContext context)
        {
            _context = context;
        }

        // GET: api/Temperature
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemperatureSensor>>> GetTemperatureSensor()
        {
            return await _context.TemperatureSensor
                .Include("TemperatureSensor.Measurement")
                .ToListAsync();
        }

        // GET: api/Temperature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemperatureSensor>> GetTemperatureSensor(int id)
        {
            var temperatureSensor = await _context.TemperatureSensor.FindAsync(id);

            if (temperatureSensor == null)
            {
                return NotFound();
            }

            return temperatureSensor;
        }

        // PUT: api/Temperature/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemperatureSensor(int id, [FromBody]TemperatureSensor temperatureSensor)
        {
            if (temperatureSensor.TemperatureSensorId != id)
            {
                return BadRequest();
            }

            _context.Entry(temperatureSensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperatureSensorExists(id))
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

        // POST: api/Temperature
        [HttpPost]
        public async Task<ActionResult<TemperatureSensor>> PostTemperatureSensor(TemperatureSensor temperatureSensor)
        {
            _context.TemperatureSensor.Add(temperatureSensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemperatureSensor", new { id = temperatureSensor.TemperatureSensorId }, temperatureSensor);
        }

        // DELETE: api/Temperature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TemperatureSensor>> DeleteTemperatureSensor(int id)
        {
            var temperatureSensor = await _context.TemperatureSensor.FindAsync(id);
            if (temperatureSensor == null)
            {
                return NotFound();
            }

            _context.TemperatureSensor.Remove(temperatureSensor);
            await _context.SaveChangesAsync();

            return temperatureSensor;
        }

        private bool TemperatureSensorExists(int id)
        {
            return _context.TemperatureSensor.Any(e => e.TemperatureSensorId == id);
        }
    }
}
