using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "My API";
        s.Version = "v1";
    };
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
