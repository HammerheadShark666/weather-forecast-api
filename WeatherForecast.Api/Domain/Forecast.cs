using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WeatherForecast.Api.Helpers;

namespace WeatherForecast.Api.Domain;

public class Forecast
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column(TypeName = "datetime2(7)")]
    [Required]
    public DateOnly Date { get; set; }

    [Column(TypeName = "int")]
    [Required]
    public int TemperatureC { get; set; }

    [Column(TypeName = "nvarchar(120)")] 
    public string? Summary { get; set; }
    
    public int TemperatureF { get { return ForecastHelper.CentigradeToFahrenheit(TemperatureC); } }

    public Forecast(long id, DateOnly date, int temperatureC, string? summary)
    {
        Id = id;
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    } 
}