using FastEndpoints;
using FluentValidation;

namespace MinimalApi.Api;

public class WeatherForecastRetrievalValidator : Validator<WeatherForecastRequest>
{
    public WeatherForecastRetrievalValidator()
    {
        RuleFor(x=>x.Days)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Weather forecast must be greater or equal to 1")
            .LessThanOrEqualTo(15)
            .WithMessage("Weather forecast can't be retrieved past 15 days");
    }
}