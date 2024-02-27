using AutoMapper;
using WeatherForecast.Api.Domain;

namespace WeatherForecast.Api.MediatR.GetMultiDayForecast;

public class GetMultiDayForecastMapper : Profile
{
    public GetMultiDayForecastMapper()
    {   
        base.CreateMap<Forecast, MultiDayForecastResponse>();

        base.CreateMap<List<Forecast>, GetMultiDayForecastResponse>()
            .ForCtorParam(ctorParamName: "Forecasts", m => m.MapFrom(s => s)); 
    }
}