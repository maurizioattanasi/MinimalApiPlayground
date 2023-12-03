using FastEndpoints;

namespace MinimalApi.Api;

public class WeatherForecastMapper : Mapper<WeatherForecastRequest, WeatherForecastResponse, WeatherForecast>
{
    public override WeatherForecastResponse FromEntity(WeatherForecast e)
        => new WeatherForecastResponse(e.Date, e.TemperatureC, e.TemperatureF, e.Summary);
}
