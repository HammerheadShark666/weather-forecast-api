using AutoMapper;
using WeatherForecast.Api.Domain;
using WeatherForecast.Api.MediatR.GetForecastForDate;

namespace WeatherForecast.Api.MediatR.AddForecast;

public class AddForecastMapper : Profile
{
    public AddForecastMapper()
    {
        base.CreateMap<Forecast, AddForecastResponse>();
    }
}