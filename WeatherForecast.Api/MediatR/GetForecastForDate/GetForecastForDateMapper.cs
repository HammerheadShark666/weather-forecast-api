using AutoMapper;
using WeatherForecast.Api.Domain;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public class GetForecastForDateMapper : Profile
{
    public GetForecastForDateMapper()
    {
        base.CreateMap<Forecast, GetForecastForDateResponse>(); 
    }
}