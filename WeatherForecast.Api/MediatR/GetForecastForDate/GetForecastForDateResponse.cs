using WeatherForecast.Api.Model;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public class GetForecastForDateResponse
{
    public Forecast? Forecast { get; set; }

    public GetForecastForDateResponse(Forecast? forecast)
    {
        Forecast = forecast;
    }
}