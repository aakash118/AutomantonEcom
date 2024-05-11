using Marten;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Add services and Dependency Injection
builder.Services.AddCarter();
builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("catalogconnectionstring")!);
}).UseLightweightSessions();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
var app = builder.Build();


//Add Http request and usings
app.MapCarter();

app.Run();
