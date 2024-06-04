using Challenge.Api.Middleware;
using Challenge.DataAccess.Repository;
using Challenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

services.AddMemoryCache();

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
	.Enrich.FromLogContext()
	.WriteTo.File("log.txt")
	.CreateLogger();


services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddControllers(option => option.EnableEndpointRouting = false).AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNamingPolicy = null;
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//DataBase
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
