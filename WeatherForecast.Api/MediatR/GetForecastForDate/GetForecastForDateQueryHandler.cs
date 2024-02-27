using AutoMapper;
using MediatR;
using WeatherForecast.Api.Data.Interfaces;

namespace WeatherForecast.Api.MediatR.GetForecastForDate;

public class GetForecastForDateQueryHandler : IRequestHandler<GetForecastForDateRequest, GetForecastForDateResponse>
{
    private readonly IForecastRepository _forecastRepository;
    private readonly IMapper _mapper;

    public GetForecastForDateQueryHandler(IForecastRepository forecastRepository, IMapper mapper)
    {
        _forecastRepository = forecastRepository;
        _mapper = mapper;
    }

    public Task<GetForecastForDateResponse> Handle(GetForecastForDateRequest request, CancellationToken cancellationToken)
    {  
        var result = _forecastRepository.GetForecast(DateOnly.FromDateTime(request.Date));
        if (result == null)
            return Task.FromResult(new GetForecastForDateResponse(default, default, default, default));

        return Task.FromResult(_mapper.Map<GetForecastForDateResponse>(result)); 
    }
}