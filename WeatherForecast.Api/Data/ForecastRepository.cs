using Microsoft.Extensions.Caching.Memory;
using WeatherForecast.Api.Data.Context;
using WeatherForecast.Api.Data.Interfaces;
using WeatherForecast.Api.Domain;
using WeatherForecast.Api.Helpers;
using WeatherForecast.Api.Helpers.Exceptions;

namespace WeatherForecast.Api.Data;

public class ForecastRepository : IForecastRepository
{ 
    private IMemoryCache _memoryCache;
    private readonly ForecastContext _context;

    private const int CacheExpirationMintues30 = 30;

    public ForecastRepository(ForecastContext context, IMemoryCache memoryCache)
    {
        _context = context; 
        _memoryCache = memoryCache;
    }

    public Forecast? GetForecast(DateOnly date)
    {
        return _memoryCache.GetOrCreate(
                                date.ToShortDateString(),
                                cacheEntry =>
                                {
                                    cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(CacheExpirationMintues30);
                                    return _context.Forecasts.SingleOrDefault(a => a.Date.Equals(date)); 
                                }); 
    }

    public List<Forecast>? GetForecast(DateOnly date, int numberOfDays)
    {
        return _memoryCache.GetOrCreate(
                                date.ToShortDateString() + numberOfDays.ToString(),
                                cacheEntry =>
                                {
                                    cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(CacheExpirationMintues30);

                                    var dates = DateHelper.GetStartEndDates(date, numberOfDays);

                                    return _context.Forecasts
                                            .Where(a => a.Date >= dates.Item1 && a.Date <= dates.Item2)
                                            .OrderBy(a => a.Date)
                                            .ToList();
                                });
    } 

    public Forecast AddForecast(Forecast forecast)
    { 
        _context.Forecasts.Add(forecast);
        _context.SaveChanges();

        return forecast;
    }

    public long GetLastId()
    {
        return _context.Forecasts.Max(a => a.Id);
    }

    public bool Exists(DateOnly date)
    {
        return _context.Forecasts.Any(a => a.Date.Equals(date));
    }

    public bool Exists(long id)
    {
        return _context.Forecasts.Any(a => a.Id.Equals(id));
    }

    public void Delete(long id)
    {
        var forecast = _context.Forecasts.FirstOrDefault(a => a.Id == id);
        if (forecast == null)
            throw new ForecastNotFoundException("Forecast not found.");
               
        _context.Forecasts.Remove(forecast);
        _context.SaveChanges();        
    }
}