using Microsoft.EntityFrameworkCore;
using WeatherForecast.Api.Domain;
using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Api.Data.Context;

public class ForecastContext : DbContext
{
    private const string DatabaseName = "ForecastsDb";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseInMemoryDatabase(databaseName: DatabaseName); 

    public DbSet<Forecast> Forecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Forecast>().HasData(ForecastHelper.CreateForecasts(Constants.NumberOfDaysForecastAvailable));
    }
}