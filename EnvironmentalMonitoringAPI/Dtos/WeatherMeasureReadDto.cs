using System;

namespace EnvironmentalMonitoringAPI.Dtos
{
    public class WeatherMeasureReadDto
    {
        public float Temperature { get; set; }

        public float Humidity { get; set; }

        public float Pressure { get; set; }

        public DateTime MeasurementTime { get; set; }
    }
}
