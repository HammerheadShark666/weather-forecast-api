using MediatR;

namespace WeatherForecast.Api.MediatR.Get5DayForecast;
public class Get5DayForecastRequest : IRequest<Get5DayForecastResponse>
{
    public DateTime Date { get; set; }

    public Get5DayForecastRequest(DateTime date)
    {
        Date = date;
    }
}
