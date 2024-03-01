using WeatherForecast.Api.Domain;

namespace WeatherForecast.Api.Helpers;

public static class ForecastHelper
{
    public static IEnumerable<Forecast> CreateForecasts(int numberOfDays)
    {
        var today = DateTime.Now;

        for (int i = 0; i < numberOfDays; i++)
        {
            yield return new Forecast
            (
                i + 1,
                DateOnly.FromDateTime(today),
                Random.Shared.Next(-20, 55),
                Constants.Summaries[Random.Shared.Next(Constants.Summaries.Length)]
            );

            today = today.AddDays(1);
        }
    }
}