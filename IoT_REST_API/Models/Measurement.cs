using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace IoT_REST_API.Models
{
    public class Measurement
    {
        [Key]
        public int MeasurementId { get; set; }

        [FromRoute]
        [Required]
        public int TemperatureSensorId { get; set; }

        [Required]
        public int Temperature { get; set; }

        [Required]
        public DateTime MeasureDate { get; set; }

        [Required]
        public DateTime MeasureTime { get; set; }
        
        public virtual TemperatureSensor TemperatureSensor { get; set; }
    }
}
