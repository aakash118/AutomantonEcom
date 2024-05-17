


var builder = WebApplication.CreateBuilder(args);

//Add services and Dependency Injection
builder.Services.AddCarter();
builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("catalogconnectionstring")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<InitializeCatalogdata>();
}

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(CustomValidationPipelineBehaviour<,>));
    config.AddOpenBehavior(typeof(CustomLoggingPipelineBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("catalogconnectionstring")!);


//Add Http request and usings

var app = builder.Build();
app.UseHealthChecks("/health", new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });

app.MapCarter();
app.UseExceptionHandler(options => { });
app.Run();
