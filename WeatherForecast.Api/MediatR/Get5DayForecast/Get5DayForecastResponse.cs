using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.MediatR.Get5DayForecast;

public class Get5DayForecastResponse
{
    public List<Forecast> Forecasts { get; set; }

    public Get5DayForecastResponse(List<Forecast> forecasts)
    {
        Forecasts = forecasts;
    } 
}


