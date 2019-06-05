using IoT_REST_API.Models;
using Microsoft.EntityFrameworkCore;

namespace IoT_REST_API.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        //Set Db table TemperatureSensor
        public DbSet<TemperatureSensor> TemperatureSensor { get; set; }

        //Set db table Measurement
        public DbSet<Measurement> Measurement { get; set; }
    }
}
