using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RedditClone;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow requests from specific origins
// Add services: add services to the container, including Swagger (just above line 9) for API documentation and CORS for cross-origin requests
// CORS configuration: configure CORS to allow requests from http:127.0.0.1 with any header and method

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder =>
    {
        builder.WithOrigins("http://127.0.0.1")
        .AllowCredentials()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true)
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline for development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable https redirection
app.UseHttpsRedirection();

// Enable CORS using the defined policy
// Above we defined a CORS policy name "AllowAllOrigins" that allows requests from http://127.0.0.1
// We are now using this policy to enable CORS in the application
app.UseCors("AllowAllOrigins");

// Read in data files to build up database
app.MapGet("/Reset", () =>
{
    using(DbContext reddit = new redditContext())
    {
        reddit.Database.EnsureDeleted();
        reddit.Database.EnsureCreated();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        using(StreamReader r = new StreamReader("dummyData.json"))
        {
            string? json = r.ReadToEnd();
            List<Topic>? source = JsonSerializer.Deserialize<List<Topic>>(json, options);
            foreach(var item in source)
            {
                reddit.Add<Topic>(item);
            }

        }
        reddit.SaveChanges();

        using(StreamReader r = new StreamReader("commentData.json"))
        {
            string? json = r.ReadToEnd();
            List<Comments>? source = JsonSerializer.Deserialize<List<Comments>>(json, options);
            foreach(var item in source)
            {
                reddit.Add<Comments>(item);
            }

        }
        reddit.SaveChanges();
        reddit.Database.ExecuteSqlRaw("PRAGMA wal_checkpoint;");

    }
    
})
.WithName("Reset Data")
.WithOpenApi();

// Define an endpoint to get topics from a JSON file
app.MapGet("/getTopics", () =>
{
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    //
    using(redditContext reddit = new redditContext())
    {
        List<Topic>? source = reddit.Topics.OrderBy(t => t.Topic_id).ToList();
        return source;
    }
}).WithOpenApi().WithName("Get Topics");

// Define an endpoint to get topics from a JSON file
app.MapGet("/getComments", () =>
{
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    using(redditContext reddit = new redditContext())
    {
        List<Comments>? source = reddit.Comments.OrderBy(t => t.Comment_id).ToList();
        return source;
    }
}).WithOpenApi().WithName("Get Comments");

// Define a simple endpoint to return a "Hello World" message
app.MapGet("/hellWorld", () =>
{
    return "Hello World from my API";
}).WithOpenApi().WithName("Hello World");

// Run the application
app.Run();

// Record type to represent weather forecast data
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    // Property to calculate temperature in Fahrenheit
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
