using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.Helpers;

public static class ForecastHelper
{
    public static List<Forecast> GetDaysOfForecasts(int numberOfDays)
    {
        List<Forecast> forecasts = new List<Forecast>();
        var today = DateTime.Now;

        for (int i = 0; i < numberOfDays; i++)
        {
            forecasts.Add(new Forecast
            (
                DateOnly.FromDateTime(today),
                Random.Shared.Next(-20, 55),
                Constants.Summaries[Random.Shared.Next(Constants.Summaries.Length)]
            ));

            today = today.AddDays(1);
        }

        return forecasts;
    }
}
