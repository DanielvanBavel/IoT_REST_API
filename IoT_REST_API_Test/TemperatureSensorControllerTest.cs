using IoT_REST_API;
using IoT_REST_API.Controllers;
using IoT_REST_API.Models;
using IoT_REST_API.Models.DataManager;
using IoT_REST_API.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IoT_REST_API_Test
{
    [TestClass]
    public class TemperatureSensorControllerTest
    {
        TemperatureSensorController _controller;
        readonly IDataRepository<TemperatureSensor> _dataRepository;
        readonly Context _context;


        public TemperatureSensorControllerTest()
        {
            _dataRepository = new TemperatureSensorManager(_context);
            _controller = new TemperatureSensorController(_dataRepository);
        }

        [TestMethod]
        public void GetSensors_ShouldReturnAllSensors()
        {
            //Arrange
            //var result = _controller.GetTemperatureSensors();

            //Assert
            //var items = Assert.IsInstanceOfType(, okResult.Value);
            //Assert.AreEqual(5, result.Result);

        }

        [TestMethod]
        public void TestGetSensorByIdWithStatusCode200Async()
        {

        }

        [TestMethod]
        public void TestAddSensorWithStatusCode201Created()
        {

        }

        [TestMethod]
        public void TestAddMeasurementToSensor()
        {

        }

        [TestMethod]
        public void TestEditSensor()
        {

        }

        [TestMethod]
        public void TestDeleteSensor()
        {
            //Act
            long id = 1;

            //Arrange
            var result = _dataRepository.DeleteAsync(id);

            //Assert
            Assert.IsTrue(result.IsCompleted);
        }
    }
}
