using IoT_REST_API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IoT_REST_API_Test
{
    [TestClass]
    public class TemperatureSensorControllerTest
    {
        TemperatureSensorControllerTest()
        {

        }

        [TestMethod]
        public void TestGetSensorsWithReturn200Succes()
        {
            //Arrange
            //string expectedTitle = "Sample2";

            //Act
            //var controller = new TemperatureSensorController(_context);
            //TemperatureSensor result = controller.GetTemperatureSensors();

            //Assert
            //Assert.IsTrue(Ok());
        }

        [TestMethod]
        public void TestGetSensorByIdWithReturn200Succes()
        {
        //    string expectedTitle = "Sample2";
        //    var controller = new TemperatureSensorController(_context);
        //    TemperatureSensor result = controller.GetTemperatureSensor(2);
        //    Assert.AreEqual(expectedTitle, result.DeviceName);
        }
    }
}
