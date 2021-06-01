using AutoMapper;
using EnvironmentalMonitoringAPI.Data;
using EnvironmentalMonitoringAPI.Dtos;
using EnvironmentalMonitoringAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MunicipalEnterprise.Controllers
{
    [Route("api/weatherMeasures")]
    [ApiController]
    public class WeatherMeasuresController : ControllerBase
    {
        private readonly IEnvironmentalMonitoringRepo _repository;
        private readonly IMapper _mapper;

        public WeatherMeasuresController(IEnvironmentalMonitoringRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<WeatherMeasureReadDto>> GetAllWeatherMeasures()
        //{
        //    var weatherMeasureItems = _repository.GetAllWeatherMeasures();
        //    return Ok(_mapper.Map<IEnumerable<WeatherMeasureReadDto>>(weatherMeasureItems));
        //}
        [HttpGet("lastHour")]
        public ActionResult<IEnumerable<WeatherMeasureReadDto>> GetLastHourWeatherMeasures()
        {
            var weatherMeasureItems = _repository.GetLastHourWeatherMeasures();
            return Ok(_mapper.Map<IEnumerable<WeatherMeasureReadDto>>(weatherMeasureItems));
        }

        [HttpGet("lastDay")]
        public ActionResult<IEnumerable<WeatherMeasureReadDto>> GetLastDayWeatherMeasures()
        {
            var weatherMeasureItems = _repository.GetLastDayWeatherMeasures();
            return Ok(_mapper.Map<IEnumerable<WeatherMeasureReadDto>>(weatherMeasureItems));
        }

        [HttpGet("lastWeek")]
        public ActionResult<IEnumerable<WeatherMeasureReadDto>> GetLastWeekWeatherMeasures()
        {
            var weatherMeasureItems = _repository.GetLastWeekWeatherMeasures();
            return Ok(_mapper.Map<IEnumerable<WeatherMeasureReadDto>>(weatherMeasureItems));
        }

        [HttpGet("{id}", Name = "GetWeatherMeasureById")]
        public ActionResult<WeatherMeasureReadDto> GetWeatherMeasureById(int id)
        {
            var districtItem = _repository.GetWeatherMeasureById(id);

            if (districtItem != null)
            {
                return Ok(_mapper.Map<WeatherMeasureReadDto>(districtItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <WeatherMeasureReadDto> CreateDto(WeatherMeasureCreateDto weatherMeasureCreateDto)
        {
            var weatherMeasureModel = _mapper.Map<WeatherMeasure>(weatherMeasureCreateDto);
            weatherMeasureModel.MeasurementTime = DateTime.Now;
            _repository.CreateWeatherMeasure(weatherMeasureModel);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetWeatherMeasureById), new { Id = weatherMeasureModel.Id }, weatherMeasureModel);
        }
    }
}
