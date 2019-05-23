using IoT_REST_API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_REST_API.Models.DataManager
{
    public class TemperatureSensorManager : IDataRepository<TemperatureSensor>
    {
        readonly Context _temperatureContext;

        public TemperatureSensorManager(Context context)
        {
            _temperatureContext = context;
        }

        public async Task<IEnumerable<TemperatureSensor>> GetAllAsync()
        {
            return await _temperatureContext.Set<TemperatureSensor>().ToListAsync();
        }

        public async Task<TemperatureSensor> GetAsync(long id)
        {
            return await _temperatureContext.TemperatureSensor.FirstOrDefaultAsync(e => e.TemperatureSensorId == id);
        }

        public async Task AddAsync(TemperatureSensor entity)
        {
            Queue<TemperatureSensor> sensorQueue = new Queue<TemperatureSensor>();

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.TemperatureSensorId <= 0)
            {
                sensorQueue.Enqueue(entity);

                if(sensorQueue.Count >= 1)
                {
                    _temperatureContext.TemperatureSensor.Add(sensorQueue.Dequeue());
                }
                else
                {
                    sensorQueue.Clear();
                }
            }

            await _temperatureContext.SaveChangesAsync();
        }

        public async Task AddMeasurementAsync(Measurement measurement)
        {
            Queue<Measurement> measurementQueue = new Queue<Measurement>();

            if (measurement == null)
            {
                throw new ArgumentNullException(nameof(measurement));
            }

            if (measurement.TemperatureSensorId >= 1)
            {
                measurementQueue.Enqueue(measurement);

                if (measurementQueue.Count >= 1)
                {
                    _temperatureContext.Measurement.Add(measurementQueue.Dequeue());
                }
                else
                {
                    measurementQueue.Clear();
                }
            }
            else
            {
                EntityEntry<Measurement> entityEntry = _temperatureContext.Entry(measurement);
                entityEntry.State = EntityState.Modified;
            }

            await _temperatureContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TemperatureSensor entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }

            _temperatureContext.TemperatureSensor.Update(entity);
            _temperatureContext.Entry(entity).State = EntityState.Modified;

            await _temperatureContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            TemperatureSensor sensor = _temperatureContext.TemperatureSensor.SingleOrDefault(x => x.TemperatureSensorId == id);

            _temperatureContext.TemperatureSensor.Remove(sensor);

            await _temperatureContext.SaveChangesAsync();
        }
    }
}
