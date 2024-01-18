namespace WeatherForecast.Api.Model;

public class Forecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }     
    public string? Summary { get; set; }
    public int TemperatureF { get { return 32 + (int)(TemperatureC / 0.5556); } }

    public Forecast(DateOnly date, int tempratureC, string? summary)
    {
        this.Date = date;
        this.TemperatureC = tempratureC;
        this.Summary = summary;
    } 
}