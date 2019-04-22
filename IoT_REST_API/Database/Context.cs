using IoT_REST_API.Models;
using Microsoft.EntityFrameworkCore;

namespace IoT_REST_API
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<TemperatureSensor> TemperatureSensor { get; set; }
        public DbSet<Measurement> Measurement { get; set; }
    }
}
