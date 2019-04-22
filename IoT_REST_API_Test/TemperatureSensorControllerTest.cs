using IoT_REST_API;
using IoT_REST_API.Controllers;
using IoT_REST_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IoT_REST_API_Test
{
    [TestClass]
    public class TemperatureSensorControllerTest
    {
        Context _context;

        TemperatureSensorControllerTest()
        {
            InitContext();
        }

        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase();

            var context = new Context(builder.Options);
            var books = Enumerable.Range(1, 10)
                .Select(i => new TemperatureSensor { TemperatureSensorId = i, DeviceName = $"Sample{i}", DeviceModel = "Wrox Press" });
            context.TemperatureSensor.AddRange(books);
            int changed = context.SaveChanges();
            _context = context;
        }

        //[TestMethod]
        //public void TestGetSensors()
        //{
        //    //Arrange
        //    string expectedTitle = "Sample2";

        //    //Act
        //    var controller = new TemperatureSensorController(_context);
        //    TemperatureSensor result = controller.GetTemperatureSensors();

        //    //Assert
        //    Assert.AreEqual(expectedTitle, result.DeviceName);
        //}

        //[TestMethod]
        //public void TestGetSensorById()
        //{
        //    string expectedTitle = "Sample2";
        //    var controller = new TemperatureSensorController(_context);
        //    TemperatureSensor result = controller.GetTemperatureSensor(2);
        //    Assert.AreEqual(expectedTitle, result.DeviceName);
        //}

    }
}
