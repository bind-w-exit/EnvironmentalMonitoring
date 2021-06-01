using System;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentalMonitoringAPI.Models
{
    public class WeatherMeasure
    {
        public int Id { get; set; }

        public float Temperature { get; set;}

        public float Humidity { get; set; }

        public float Pressure { get; set; }

        public DateTime MeasurementTime { get; set; }

        [Required]
        [StringLength(17)]
        public string MacAddress { get; set; }
    }
}
