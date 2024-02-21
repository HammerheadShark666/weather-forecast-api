using AutoMapper;
using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;
public class GetForecastForDateMapper:Profile
{
    public GetForecastForDateMapper()
    {
        CreateMap<Forecast, GetForecastForDateResponse?>();
    }
}