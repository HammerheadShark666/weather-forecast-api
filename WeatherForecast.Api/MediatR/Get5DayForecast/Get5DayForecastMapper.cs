using AutoMapper;
using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.MediatR.Get5DayForecast;
public class Get5DayForecastMapper:Profile
{
    public Get5DayForecastMapper()
    {
        CreateMap<Forecast, Get5DayForecastResponse>();
    }
}
