using WeatherForecast.Api.Helpers;
using WeatherForecast.Api.Model;
using WeatherForecast.Api.Services.Interfaces;

namespace WeatherForecast.Api.Services;

public class WeatherForecastService : IWeatherForecastService
{
    public Forecast GetForecast(DateTime date)
    {
        return new Forecast
            (
                DateOnly.FromDateTime(date),
                Random.Shared.Next(-20, 55),
                Constants.Summaries[Random.Shared.Next(Constants.Summaries.Length)]
            );
    }

    public List<Forecast> GetForecast(int rangeFrom, int rangeTo)
    {
        return Enumerable.Range(rangeFrom, rangeTo).Select(index =>
            new Forecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Constants.Summaries[Random.Shared.Next(Constants.Summaries.Length)]
            )).ToList();
    }
}