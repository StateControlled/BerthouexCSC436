using System.Text.Json;
using RedditClone;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/getTopics", () =>
{
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    using (StreamReader r = new StreamReader("dummyData.json")) {
        string? json = r.ReadToEnd();
        List<Topic> source = JsonSerializer.Deserialize<List<Topic>>(json, options);
        return source;
    }
}).WithOpenApi().WithName("Get Topics");

app.MapGet("/getComments", () =>
{
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    using (StreamReader r = new StreamReader("commentData.json")) {
        string? json = r.ReadToEnd();
        List<Comment> source = JsonSerializer.Deserialize<List<Comment>>(json, options);
        return source;
    }
}).WithOpenApi().WithName("Get Comments");

app.MapGet("/helloWorld", () =>
{

    return "Hello World from my API";
}).WithOpenApi().WithName("Hello World");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}