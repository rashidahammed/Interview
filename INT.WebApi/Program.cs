using INT.Application.Application.Interfaces;
using INT.Infrastructure.Infrastructure.IoC;
using INT.WebApi.MiddleWares;

var builder = WebApplication.CreateBuilder(args);


var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

builder.Services.RegisterBusinessServices();
builder.Services.ConfigureInfrastructure(appSettings);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//using (var scope = app.Services.CreateScope())
//{
//    scope.ServiceProvider.MigrateDatabase();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<CurrentUserContextMiddleware>();

app.MapControllers();

app.Run();
