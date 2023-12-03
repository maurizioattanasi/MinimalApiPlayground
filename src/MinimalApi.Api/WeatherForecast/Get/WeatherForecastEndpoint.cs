using FastEndpoints;

namespace MinimalApi.Api;

public class WeatherForecastEndpoint : Endpoint<WeatherForecastRequest, IEnumerable<WeatherForecastResponse>, WeatherForecastMapper>
{
    private static readonly string[] summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("weatherforecast/{days}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
    {
        var forecasts = Enumerable.Range(1, req.Days).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ));

        var response = forecasts.Select(Map.FromEntity);

        await SendAsync(response, cancellation: ct);
    }
}
