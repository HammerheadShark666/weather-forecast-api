using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.Data.Interfaces;

public interface IForecastRepository
{
    Forecast? GetForecast(DateTime date);
    List<Forecast> GetForecast(DateTime date, int numberOfDays);
}