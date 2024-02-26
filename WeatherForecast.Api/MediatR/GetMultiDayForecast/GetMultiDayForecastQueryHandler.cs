using MediatR;
using WeatherForecast.Api.Data.Interfaces;

namespace WeatherForecast.Api.MediatR.GetMultiDayForecast;

public class GetForecastForDateQueryHandler : IRequestHandler<GetMultiDayForecastRequest, GetMultiDayForecastResponse>
{
    private readonly IForecastRepository _forecastRepository;

    public GetForecastForDateQueryHandler(IForecastRepository forecastRepository)
    {
        _forecastRepository = forecastRepository;
    }

    public Task<GetMultiDayForecastResponse> Handle(GetMultiDayForecastRequest request, CancellationToken cancellationToken)
    {
        var result = _forecastRepository.GetForecast(DateOnly.FromDateTime(request.Date), request.NumberOfDays);
        if (!result.Any())
            return Task.FromResult(new GetMultiDayForecastResponse(default));

        return Task.FromResult(new GetMultiDayForecastResponse(result));        
    }
}