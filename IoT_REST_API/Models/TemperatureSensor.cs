using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoT_REST_API.Models
{
    public class TemperatureSensor
    {
        [Key]
        public int TemperatureSensorId { get; set; }

        public string DeviceName  { get; set; }

        public string DeviceModel { get; set; }

        public string LocationName { get; set; }

        public bool IsOnline { get; set; }

        public List<Measurement> Measurements { get; set; }
    }
}
