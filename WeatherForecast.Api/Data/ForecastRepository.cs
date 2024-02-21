using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Helpers;
using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.Data;

public class ForecastRepository : IForecastRepository
{
    private List<Forecast> _forecasts { get; set; }

    public ForecastRepository()
    {
        _forecasts = Get14DaysOfForecasts();
    }

    public Forecast? GetForecast(DateTime date)
    {
        return _forecasts.SingleOrDefault(a => a.Date.Equals(DateOnly.FromDateTime(date)));
    }

    public List<Forecast> GetForecast(DateTime date, int numberOfDays)
    {
        var index = _forecasts.FindIndex(a => a.Date.Equals(DateOnly.FromDateTime(date)));
        return _forecasts.GetRange(index, numberOfDays);
    }

    private List<Forecast> Get14DaysOfForecasts()
    {
        List<Forecast> forecasts = new List<Forecast>();
        var today = DateTime.Now;

        for (int i = 0; i < 14; i++)
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