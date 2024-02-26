using MediatR;
using WeatherForecast.Api.Data.Interfaces;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public class GetForecastForDateQueryHandler : IRequestHandler<GetForecastForDateRequest, AddForecastResponse>
{
    private readonly IForecastRepository _forecastRepository; 

    public GetForecastForDateQueryHandler(IForecastRepository forecastRepository)
    {
        _forecastRepository = forecastRepository;
    }

    public Task<AddForecastResponse> Handle(GetForecastForDateRequest request, CancellationToken cancellationToken)
    {  
        var result = _forecastRepository.GetForecast(DateOnly.FromDateTime(request.Date));
        if (result == null)
            return Task.FromResult(new AddForecastResponse(default));

        return Task.FromResult(new AddForecastResponse(result)); 
    }
}