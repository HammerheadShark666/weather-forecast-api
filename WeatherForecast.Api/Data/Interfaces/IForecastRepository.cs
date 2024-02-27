using WeatherForecast.Api.Domain;

namespace WeatherForecast.Api.Data.Interfaces;

public interface IForecastRepository
{
    Forecast? GetForecast(DateOnly date);
    List<Forecast>? GetForecast(DateOnly date, int numberOfDays);
    Forecast AddForecast(Forecast forecast);
    long GetLastId();    
    void Delete(long id);
    bool Exists(long id);
    bool Exists(DateOnly date);
}