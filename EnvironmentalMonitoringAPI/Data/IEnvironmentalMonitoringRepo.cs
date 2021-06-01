using EnvironmentalMonitoringAPI.Models;
using System.Collections.Generic;

namespace EnvironmentalMonitoringAPI.Data
{
    public interface IEnvironmentalMonitoringRepo
    {
        bool SaveChanges();

        //IEnumerable<WeatherMeasure> GetAllWeatherMeasures();
        WeatherMeasure GetWeatherMeasureById(int id);
        void CreateWeatherMeasure(WeatherMeasure district);
        IEnumerable<WeatherMeasure> GetLastHourWeatherMeasures();
        IEnumerable<WeatherMeasure> GetLastDayWeatherMeasures();
        IEnumerable<WeatherMeasure> GetLastWeekWeatherMeasures();
    }
}
