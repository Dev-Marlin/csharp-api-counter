using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.EndPoints;
using api_counter.wwwapi9.Models;
using api_counter.wwwapi9.Repository;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// shares IRepository to every request in the app
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

CounterHelper.Initialize();

IRepository repo = new Repository();

CounterEndpoints.InitializeEndpoints(app);

app.Run();
