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

        // GET: api/v1/temperaturesensor
        [HttpGet]
        public async Task<IEnumerable<TemperatureSensor>> GetTemperatureSensors()
        {
            return await _dataRepository.GetAllAsync();
        }

        // GET: api/v1/temperaturesensor/{id}
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

        // POST: api/v1/temperaturesensor
        [HttpPost]
        public async Task<ActionResult<TemperatureSensor>> Post([FromBody] TemperatureSensor temperatureSensor)
        {
            if (temperatureSensor == null)
            {
                return BadRequest("temperatureSensor is null.");
            }

            await _dataRepository.AddAsync(temperatureSensor);

            return Ok(temperatureSensor);
        }

        // POST: api/v1/temperaturesensor/{id}/measurement
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

        //PUT: api/v1/temperaturesensor/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<TemperatureSensor>> EditTemperatureSensor(long id, [FromBody] TemperatureSensor temperatureSensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            temperatureSensor.TemperatureSensorId = id;

            await _dataRepository.UpdateAsync(temperatureSensor);

            return NoContent();
        }

        //DELETE: api/v1/temperaturesensor/{id}
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
