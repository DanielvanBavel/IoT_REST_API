using IoT_REST_API.Database;
using IoT_REST_API.Models;
using IoT_REST_API.Models.DataManager;
using IoT_REST_API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

        }

        [TestMethod]
        public void TestPostNewMeasurement()
        {

        }

        [TestMethod]
        public void TestEditSensor()
        {
        }

        [TestMethod]
        public void TestEditMeasurement()
        {
        }

        [TestMethod]
        public async void TestDeleteSensor()
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

            await repository.DeleteAsync(3);

            Assert.AreEqual(0, context.TemperatureSensor.Count());
        }
    }
}
