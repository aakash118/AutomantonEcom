var builder = WebApplication.CreateBuilder(args);


#region Build services
var app = builder.Build();
#endregion

#region Use services
app.Run();
#endregion
