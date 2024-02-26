using Microsoft.Extensions.Caching.Memory;
using Moq;
using WeatherForecast.Api.Data;
using WeatherForecast.Api.Domain;
using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Test.Services;

public class WeatherForecastServiceTest
{
    private readonly ForecastRepository _forecast;

    //public WeatherForecastServiceTest()
    //{ 
    //    //_forecast = new ForecastRepository();
    //}

    //[Fact]
    //public void get_weather_forecast_for_range_return_5_day_weather_forecast()
    //{ 
    //    List<Forecast> response = _forecast.GetForecast(DateOnly.FromDateTime(DateTime.Now), 5);

    //    Assert.Equal(5, response.Count);
    //}

    //[Fact]
    //public void get_weather_forecast_for_number_of_days_from_today_return_3_day_weather_forecast()
    //{        
    //    List<Forecast> response = _forecast.GetForecast(DateOnly.FromDateTime(DateTime.Now), 3);

    //    Assert.Equal(3, response.Count);
    //}

    //[Fact]
    //public void get_weather_forecast_for_no_range_return_1_day_weather_forecast()
    //{       
    //    List<Forecast> response = _forecast.GetForecast(DateOnly.FromDateTime(DateTime.Now), 0);

    //    Assert.Empty(response);
    //}

    //[Fact]
    //public void get_weather_forecast_for_date_return_1_day_weather_forecast()
    //{
    //    Forecast? response = _forecast.GetForecast(DateOnly.FromDateTime(DateTime.Now));

    //    Assert.NotNull(response);
    //    Assert.True(response.GetType() == typeof(Forecast));
    //    Assert.Equal(response.Date, DateOnly.FromDateTime(DateTime.Now));
    //    Assert.InRange(response.TemperatureC, -20, 55);
    //    Assert.InRange(response.TemperatureF, -4, 131);
    //    Assert.Contains(response.Summary, Constants.Summaries);
    //}
}