var builder = WebApplication.CreateBuilder(args);

//builder services
builder.Services.AddCarter();
//Initialze seed data fror Basket
builder.Services.AddMarten(options =>
    {
        options.Connection(builder.Configuration.GetConnectionString("basketconnectionstring")!);
    }).UseLightweightSessions();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(CustomLoggingPipelineBehaviour<,>));
    config.AddOpenBehavior(typeof(CustomValidationPipelineBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
//Health checks
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("basketconnectionstring")!)
    .AddRedis(builder.Configuration.GetConnectionString("basketredis")!);
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasktetRepository>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("basketredis");
});
var app = builder.Build();


//Map pipelines and http requests
app.MapCarter();
app.MapHealthChecks("/health", new HealthCheckOptions
{ ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
app.UseExceptionHandler(config => { });
app.Run();

