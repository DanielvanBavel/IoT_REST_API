using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace IoT_REST_API.Models
{
    public class Measurement
    {
        [Key]
        public long MeasurementId { get; set; }

        [FromRoute]
        [Required]
        public long TemperatureSensorId { get; set; }

        [Required]
        public int Temperature { get; set; }

        [Required]
        public string MeasureDate { get; set; }

        [Required]
        public string MeasureTime { get; set; }
        
        public virtual TemperatureSensor TemperatureSensor { get; set; }
    }
}
