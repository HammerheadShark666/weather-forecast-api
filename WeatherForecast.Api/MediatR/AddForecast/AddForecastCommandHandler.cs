using MediatR;
using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Domain;
using WeatherForecast.Api.MediatR.GetForecastForDate;

namespace WeatherForecast.Api.MediatR.AddForecast;

public class AddForecastCommandHandler : IRequestHandler<AddForecastRequest, AddForecastResponse>
{
    private readonly IForecastRepository _forecastRepository;

    public AddForecastCommandHandler(IForecastRepository forecastRepository)
    {
        _forecastRepository = forecastRepository;
    }

    public Task<AddForecastResponse> Handle(AddForecastRequest request, CancellationToken cancellationToken)
    {
        var nextId = _forecastRepository.GetLastId() + 1;
        var forecast = _forecastRepository.AddForecast(new Forecast(nextId, request.Date, request.TemperatureC, request.Summary));  
        
        return Task.FromResult(new AddForecastResponse(forecast));
    }
}