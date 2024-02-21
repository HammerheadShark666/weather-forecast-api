using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Helpers;
using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.Data;

public class ForecastRepository : IForecastRepository
{
    private List<Forecast> _forecasts { get; set; }

    public ForecastRepository()
    {
        _forecasts = ForecastHelper.GetDaysOfForecasts(14);
    }

    public Forecast? GetForecast(DateTime date)
    {
        return _forecasts.SingleOrDefault(a => a.Date.Equals(DateOnly.FromDateTime(date)));
    }

    public List<Forecast> GetForecast(DateTime date, int numberOfDays)
    {
        var index = _forecasts.FindIndex(a => a.Date.Equals(DateOnly.FromDateTime(date)));
        if (index == -1)
            return new List<Forecast>();

        return _forecasts.GetRange(index, _forecasts.Count < numberOfDays ? _forecasts.Count : numberOfDays);
    } 
}