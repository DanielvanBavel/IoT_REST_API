using IoT_REST_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoT_REST_API.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<TEntity> GetAsync(long id);

        Task AddTemperatureSensorAsync(TEntity entity);

        Task AddMeasurementAsync(Measurement entity);

        Task UpdateTemperatureSensorAsync(long id, TEntity entity);

        Task DeleteAsync(long id);
    }
}
