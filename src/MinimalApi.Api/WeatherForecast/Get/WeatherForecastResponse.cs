namespace MinimalApi.Api;

public record WeatherForecastResponse(DateOnly Date, int TemperatureC, int TemperatureF, string? Summary);
