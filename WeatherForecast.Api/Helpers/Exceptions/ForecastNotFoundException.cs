namespace WeatherForecast.Api.Helpers.Exceptions;

public class ForecastNotFoundException : Exception
{
    public ForecastNotFoundException()
    {
    }

    public ForecastNotFoundException(string message)
        : base(message)
    {
    }

    public ForecastNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}