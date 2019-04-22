using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoT_REST_API.Models
{
    public class TemperatureSensor
    {
        [Key]
        public long TemperatureSensorId { get; set; }

        [Required]
        public string DeviceName  { get; set; }

        [Required]
        public string DeviceModel { get; set; }

        [Required]
        public string LocationName { get; set; }

        [Required]
        public bool IsOnline { get; set; }

        public virtual List<Measurement> Measurements { get; set; }
    }
}
