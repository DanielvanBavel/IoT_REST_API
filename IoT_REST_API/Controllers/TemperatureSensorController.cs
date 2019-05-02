using IoT_REST_API.Models;
using IoT_REST_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoT_REST_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TemperatureSensorController : ControllerBase
    {
        private readonly IDataRepository<TemperatureSensor> _dataRepository;

        public TemperatureSensorController(IDataRepository<TemperatureSensor> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Temperaturesensor
        [HttpGet]
        public async Task<IEnumerable<TemperatureSensor>> GetTemperatureSensors()
        {
            return await _dataRepository.FindAllAsync();
        }

        // GET: api/Temperaturesensor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            TemperatureSensor tempsensor = await _dataRepository.GetAsync(id);

            if (tempsensor == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(tempsensor);
        }

        // POST: api/Temperaturesensor
        [HttpPost]
        public async Task<ActionResult<TemperatureSensor>> Post([FromBody] TemperatureSensor temperatureSensor)
        {
            if (temperatureSensor == null)
            {
                return BadRequest("temperatureSensor is null.");
            }

            await _dataRepository.AddTemperatureSensorAsync(temperatureSensor);

            return Ok(temperatureSensor);
        }

        // POST: api/Temperaturesensor/5/measurement
        [HttpPost("{id}/measurement")]
        public async Task<IActionResult> AddMeasurement(long id, Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            measurement.TemperatureSensorId = id;

            await _dataRepository.AddMeasurementAsync(measurement);

            return Ok(measurement);
        }

        //DELETE: api/Temperaturesensor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemperatureSensorAsync(long id)
        {
            TemperatureSensor tempsens = await _dataRepository.GetAsync(id);
            if (tempsens == null)
            {
                return NotFound("The temperaturesensor record couldn't be found.");
            }

            await _dataRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
