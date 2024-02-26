using MediatR;
using WeatherForecast.Api.Data.Interfaces;

namespace WeatherForecast.Api.MediatR.DeleteForecast;

public class DeleteForecastCommandHandler : IRequestHandler<DeleteForecastRequest, Unit>
{
    private readonly IForecastRepository _forecastRepository;

    public DeleteForecastCommandHandler(IForecastRepository forecastRepository)
    {
        _forecastRepository = forecastRepository;
    }

    public Task<Unit> Handle(DeleteForecastRequest request, CancellationToken cancellationToken)
    {  
        _forecastRepository.Delete(request.Id);  
        return Task.FromResult(Unit.Value);
    }
}