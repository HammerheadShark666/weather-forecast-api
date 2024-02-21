using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Model;
using WeatherForecast.Api.Services.Interfaces;

namespace WeatherForecast.Api.Services;

public class WeatherForecastService : IWeatherForecastService
{ 
    IForecastRepository _forecastRepository;

    public WeatherForecastService(IForecastRepository forecastRepository)
    { 
        _forecastRepository = forecastRepository;
    }

    public Forecast? GetForecast(DateTime date)
    {
        return _forecastRepository.GetForecast(date);
    }

    public List<Forecast> GetForecast(DateTime date, int numberOfDays)
    {         
        return _forecastRepository.GetForecast(date, numberOfDays);
    }  
}