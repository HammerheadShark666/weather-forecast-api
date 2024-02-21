using MediatR;
using WeatherForecast.Api.Services.Interfaces;

namespace WeatherForecast.Api.MediatR.Get5DayForecast;

public class GetForecastForDateQueryHandler : IRequestHandler<Get5DayForecastRequest, Get5DayForecastResponse>
{
    private readonly IWeatherForecastService _weatherForecast;

    public GetForecastForDateQueryHandler(IWeatherForecastService weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    public Task<Get5DayForecastResponse> Handle(Get5DayForecastRequest request, CancellationToken cancellationToken)
    {
        var result = _weatherForecast.GetForecast(request.Date, 5);
        if (!result.Any())
            return Task.FromResult(new Get5DayForecastResponse(default));

        return Task.FromResult(new Get5DayForecastResponse(result));        
    }
}