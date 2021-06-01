using AutoMapper;
using EnvironmentalMonitoringAPI.Dtos;
using EnvironmentalMonitoringAPI.Models;

namespace MunicipalEnterprise.Profiles
{
    public class WeatherMeasuresProfile : Profile
    {
        public WeatherMeasuresProfile()
        {
            CreateMap<WeatherMeasure, WeatherMeasureReadDto>();
            CreateMap<WeatherMeasureCreateDto, WeatherMeasure>();
        }
    }
}
