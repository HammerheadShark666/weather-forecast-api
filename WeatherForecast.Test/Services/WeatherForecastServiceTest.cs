using WeatherForecast.Api.Helpers;
using WeatherForecast.Api.Model;
using WeatherForecast.Api.Services;

namespace WeatherForecast.Test.Services;

public class WeatherForecastServiceTest
{  
    [Fact]
    public void get_weather_forecast_for_range_return_5_day_weather_forecast()
    {
        WeatherForecastService weatherForecastService = new WeatherForecastService();

        List<Forecast> response = weatherForecastService.GetForecast(1, 5);

        Assert.Equal(5, response.Count);
    }

    [Fact]
    public void get_weather_forecast_for_no_range_return_0_day_weather_forecast()
    {
        WeatherForecastService weatherForecastService = new WeatherForecastService();

        List<Forecast> response = weatherForecastService.GetForecast(0, 0);

        Assert.Empty(response);
    }

    [Fact]
    public void get_weather_forecast_for_date_return_1_day_weather_forecast()
    {
        WeatherForecastService weatherForecastService = new WeatherForecastService();

        Forecast response = weatherForecastService.GetForecast(DateTime.Now);
         
        Assert.True(response.GetType() == typeof(Forecast));
        Assert.Equal(response.Date, DateOnly.FromDateTime(DateTime.Now));
        Assert.InRange(response.TemperatureC, -20, 55);
        Assert.InRange(response.TemperatureC, -4, 131); 
        Assert.Contains(response.Summary, Constants.Summaries);
    }
}