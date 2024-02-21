using MediatR;
using WeatherForecast.Api.Services.Interfaces;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public class GetForecastForDateQueryHandler : IRequestHandler<GetForecastForDateRequest, GetForecastForDateResponse>
{
    private readonly IWeatherForecastService _weatherForecastService; 

    public GetForecastForDateQueryHandler(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService; 
    }

    public Task<GetForecastForDateResponse> Handle(GetForecastForDateRequest request, CancellationToken cancellationToken)
    {  
        var result = _weatherForecastService.GetForecast(request.Date);
        if (result == null)
            return Task.FromResult(new GetForecastForDateResponse(default));

        return Task.FromResult(new GetForecastForDateResponse(result)); 
    }
}