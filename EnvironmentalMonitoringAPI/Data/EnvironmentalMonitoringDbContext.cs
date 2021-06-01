using EnvironmentalMonitoringAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentalMonitoringAPI.Data
{
    public class EnvironmentalMonitoringDbContext : DbContext
    {
        public EnvironmentalMonitoringDbContext(DbContextOptions<EnvironmentalMonitoringDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherMeasure> WeatherMeasures { get; set; }
    }
}
