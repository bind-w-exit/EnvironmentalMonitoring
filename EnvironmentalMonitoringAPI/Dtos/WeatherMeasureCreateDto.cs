using System.ComponentModel.DataAnnotations;

namespace EnvironmentalMonitoringAPI.Dtos
{
    public class WeatherMeasureCreateDto
    {
        public float Temperature { get; set; }

        public float Humidity { get; set; }

        public float Pressure { get; set; }

        [Required]
        [StringLength(17)]
        public string MacAddress { get; set; }
    }
}
