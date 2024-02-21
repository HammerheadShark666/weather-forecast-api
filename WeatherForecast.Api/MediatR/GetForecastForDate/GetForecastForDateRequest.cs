using MediatR;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;
public class GetForecastForDateRequest : IRequest<GetForecastForDateResponse>
{
    public DateTime Date { get; set; }

    public GetForecastForDateRequest(DateTime date)
    {
        Date = date;
    }
}
