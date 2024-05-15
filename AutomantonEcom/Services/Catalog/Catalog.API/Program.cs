
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
    config.AddOpenBehavior(typeof(CustomValidationPipelineBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();


//Add Http request and usings
app.MapCarter();
app.UseExceptionHandler(options => { });
app.Run();
