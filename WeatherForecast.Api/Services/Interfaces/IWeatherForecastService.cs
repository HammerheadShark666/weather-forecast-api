using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.Services.Interfaces;

public interface IWeatherForecastService
{
    Forecast? GetForecast(DateTime date);
    List<Forecast> GetForecast(DateTime date, int numberOfDays); 
}