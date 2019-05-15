using IoT_REST_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoT_REST_API.Repository
{
    public interface IDataRepository<TEntity>
    {
        /// <summary>
        /// Generic Task to receive all data object
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Generic method to receive one data object by passing a id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(long id);

        /// <summary>
        /// Generic method to add a data object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Task to add an measurement to a sensor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddMeasurementAsync(Measurement measurement);

        /// <summary>
        /// Task to update a data object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Task to delete a data object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(long id);
    }
}
