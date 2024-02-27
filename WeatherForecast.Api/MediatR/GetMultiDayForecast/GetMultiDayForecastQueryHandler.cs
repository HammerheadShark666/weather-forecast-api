using AutoMapper;
using MediatR;
using WeatherForecast.Api.Data.Interfaces;

namespace WeatherForecast.Api.MediatR.GetMultiDayForecast;

public class GetForecastForDateQueryHandler : IRequestHandler<GetMultiDayForecastRequest, GetMultiDayForecastResponse>
{
    private readonly IForecastRepository _forecastRepository;
    private readonly IMapper _mapper;

    public GetForecastForDateQueryHandler(IForecastRepository forecastRepository, IMapper mapper)
    {
        _forecastRepository = forecastRepository;
        _mapper = mapper;
    }

    public Task<GetMultiDayForecastResponse> Handle(GetMultiDayForecastRequest request, CancellationToken cancellationToken)
    {
        var result = _forecastRepository.GetForecast(DateOnly.FromDateTime(request.Date), request.NumberOfDays);
        if (result != null &&  !result.Any())
            return Task.FromResult(new GetMultiDayForecastResponse(default)); 

        return Task.FromResult(_mapper.Map<GetMultiDayForecastResponse>(result));        
    }
}