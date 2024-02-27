using AutoMapper;
using MediatR;
using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Domain;
using WeatherForecast.Api.MediatR.GetForecastForDate;

namespace WeatherForecast.Api.MediatR.AddForecast;

public class AddForecastCommandHandler : IRequestHandler<AddForecastRequest, AddForecastResponse>
{
    private readonly IForecastRepository _forecastRepository;
    private readonly IMapper _mapper;

    public AddForecastCommandHandler(IForecastRepository forecastRepository, IMapper mapper)
    {
        _forecastRepository = forecastRepository;
        _mapper = mapper;
    }

    public Task<AddForecastResponse> Handle(AddForecastRequest request, CancellationToken cancellationToken)
    {
        var nextId = _forecastRepository.GetLastId() + 1;
        var result = _forecastRepository.AddForecast(new Forecast(nextId, request.Date, request.TemperatureC, request.Summary));
 
        return Task.FromResult(_mapper.Map<AddForecastResponse>(result));
    }
}