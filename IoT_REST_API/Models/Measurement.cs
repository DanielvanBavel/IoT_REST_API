using System;
using System.ComponentModel.DataAnnotations;

namespace IoT_REST_API.Models
{
    public class Measurement
    {
        [Key]
        public int MeasurementId { get; set; }

        public int TemperatureSensorId { get; set; }

        public int Temperature { get; set; }

        public DateTime MeasureDate { get; set; }

        public DateTime MeasureTime { get; set; }
        

        public TemperatureSensor TemperatureSensor { get; set; }
    }
}
