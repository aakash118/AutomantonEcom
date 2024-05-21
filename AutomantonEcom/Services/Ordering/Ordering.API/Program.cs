using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InjectApplicationServices()
    .InjectInfrastructureServices(builder.Configuration)
    .InjectAPIServices();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAPIServices();




app.Run();


