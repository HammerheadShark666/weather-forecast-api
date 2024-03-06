using WeatherForecast.Api.Domain;
using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Test.Helpers;

public class ForecastHelperTest
{
    [Fact]
    public void Get_zero_centigrade_to_fahrenheit_return_32()
    {
        var expectedResult = 32;
        var centigradeValue = 0;

        var actualResult = ForecastHelper.CentigradeToFahrenheit(centigradeValue);

        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Get_minus_ten_centigrade_to_fahrenheit_return_14()
    {
        var expectedResult = 14;
        var centigradeValue = -10;

        var actualResult = ForecastHelper.CentigradeToFahrenheit(centigradeValue);

        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Get_plus_ten_centigrade_to_fahrenheit_return_50()
    {
        var expectedResult = 50;
        var centigradeValue = 10;

        var actualResult = ForecastHelper.CentigradeToFahrenheit(centigradeValue);

        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Get_10_forecasts_from_today_return_10_forecasts()
    {
        var numberOfForecasts = 10;
        var expectedStartDate = DateOnly.FromDateTime(DateTime.Now);
        var expectedEndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(numberOfForecasts - 1));

        var actualResult = ForecastHelper.CreateForecasts(numberOfForecasts);

        Assert.Equal(numberOfForecasts, actualResult.Count());
        Assert.IsType<Forecast>(actualResult.First());

        Assert.Equal(expectedStartDate, actualResult.First().Date);
        Assert.Equal(expectedEndDate, actualResult.Last().Date);
    }
}