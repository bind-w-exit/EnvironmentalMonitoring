using EnvironmentalMonitoringAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnvironmentalMonitoringAPI.Data
{
    public class SqlEnvironmentalMonitoringRepo : IEnvironmentalMonitoringRepo
    {
        private readonly EnvironmentalMonitoringDbContext _context;

        public SqlEnvironmentalMonitoringRepo(EnvironmentalMonitoringDbContext context)
        {
            _context = context;
        }

        public void CreateWeatherMeasure(WeatherMeasure weatherMeasure)
        {
            if (weatherMeasure == null)
            {
                throw new ArgumentNullException(nameof(weatherMeasure));
            }

            _context.WeatherMeasures.Add(weatherMeasure);
        }

        //public IEnumerable<WeatherMeasure> GetAllWeatherMeasures()
        //{
        //    return _context.WeatherMeasures.ToList();
        //}

        public WeatherMeasure GetWeatherMeasureById(int id)
        {
            return _context.WeatherMeasures.FirstOrDefault(w => w.Id == id);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<WeatherMeasure> GetLastHourWeatherMeasures()
        {
            return _context.WeatherMeasures.Where(w => w.MeasurementTime <= DateTime.Now && w.MeasurementTime >= DateTime.Now.AddHours(-1));
        }

        public IEnumerable<WeatherMeasure> GetLastDayWeatherMeasures()
        {
            return _context.WeatherMeasures.Where(w => w.MeasurementTime <= DateTime.Now && w.MeasurementTime >= DateTime.Now.AddDays(-1));
        }

        public IEnumerable<WeatherMeasure> GetLastWeekWeatherMeasures()
        {
            return _context.WeatherMeasures.Where(w => w.MeasurementTime <= DateTime.Now && w.MeasurementTime >= DateTime.Now.AddDays(-7));
        }
    }
}
