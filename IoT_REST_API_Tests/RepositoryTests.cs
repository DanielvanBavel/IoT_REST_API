using IoT_REST_API.Database;
using IoT_REST_API.Models;
using IoT_REST_API.Models.DataManager;
using IoT_REST_API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IoT_REST_API_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void TestGetAllSensors()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            Context context = new Context(optionsBuilder.Options);

            context.TemperatureSensor.Add(new TemperatureSensor()
            {
                TemperatureSensorId = 1,
                DeviceName = "Device-1",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Groningen"
            });

            context.TemperatureSensor.Add(new TemperatureSensor()
            {
                TemperatureSensorId = 2,
                DeviceName = "Device-2",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Breda"
            });

            context.TemperatureSensor.Add(new TemperatureSensor()
            {
                TemperatureSensorId = 3,
                DeviceName = "Device-3",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Amsterdam"
            });

            context.TemperatureSensor.Add(new TemperatureSensor()
            {
                TemperatureSensorId = 4,
                DeviceName = "Device-4",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Rotterdam"
            });

            context.SaveChanges();

            IDataRepository<TemperatureSensor> repository = new TemperatureSensorManager(context);

            Assert.AreEqual(4, context.TemperatureSensor.Count());
        }

        [TestMethod]
        public void TestGetSensorById()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            Context context = new Context(optionsBuilder.Options);

            context.TemperatureSensor.Add(new TemperatureSensor()
            {
                TemperatureSensorId = 1,
                DeviceName = "Device-abcde",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Groningen"
            });

            context.SaveChanges();

            IDataRepository<TemperatureSensor> repository = new TemperatureSensorManager(context);

            var repo = repository.GetAsync(1);

            Assert.IsNotNull(repo);

        }

        [TestMethod]
        public void TestPostNewSensor()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            Context context = new Context(optionsBuilder.Options);

            var Entity = new TemperatureSensor()
            {
                TemperatureSensorId = 1,
                DeviceName = "Device-abcde",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Groningen"
            };

            context.TemperatureSensor.Add(Entity);

            context.SaveChangesAsync();

            IDataRepository<TemperatureSensor> repository = new TemperatureSensorManager(context);

            repository.AddAsync(Entity);

            Assert.AreEqual(1, context.TemperatureSensor.Count());

        }

        [TestMethod]
        public void TestPostNewMeasurement()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            Context context = new Context(optionsBuilder.Options);

            context.TemperatureSensor.Add(new TemperatureSensor()
            {
                TemperatureSensorId = 1,
                DeviceName = "Device-abcde",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Groningen"
            });

            var EntityMeasurement = new Measurement()
            {
                TemperatureSensorId = 1,
                Temperature = 35,
                MeasureDate = "07-06-2019",
                MeasureTime = "12:51"
            };

            context.Measurement.Add(EntityMeasurement);

            context.SaveChangesAsync();

            IDataRepository<TemperatureSensor> repository = new TemperatureSensorManager(context);

            repository.AddMeasurementAsync(EntityMeasurement);

            Assert.AreEqual(1, context.TemperatureSensor.Count());
        }

        [TestMethod]
        public void TestEditSensor()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            Context context = new Context(optionsBuilder.Options);

            var Entity = new TemperatureSensor()
            {
                TemperatureSensorId = 1,
                DeviceName = "Device-abcde",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Groningen"
            };

            context.TemperatureSensor.Add(Entity);

            context.SaveChangesAsync();

            Entity.DeviceName = "Device-12345";
            Entity.LocationName = "Amsterdam";

            context.TemperatureSensor.Update(Entity);

            IDataRepository<TemperatureSensor> repository = new TemperatureSensorManager(context);

            repository.UpdateAsync(Entity);

            Assert.AreEqual(Entity.DeviceName, "Device-12345");
        }

        [TestMethod]
        public void TestDeleteSensor()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            Context context = new Context(optionsBuilder.Options);

            context.TemperatureSensor.Add(new TemperatureSensor()
            {
                TemperatureSensorId = 1,
                DeviceName = "Device-1",
                DeviceModel = "Model1B",
                IsOnline = true,
                LocationName = "Groningen"
            });

            IDataRepository<TemperatureSensor> repository = new TemperatureSensorManager(context);

            repository.DeleteAsync(3);

            Assert.AreEqual(0, context.TemperatureSensor.Count());
        }
    }
}
