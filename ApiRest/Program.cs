using ApiRest.Database.Context;
using ApiRest.Entities;
using ApiRest.Middleware;
using ApiRest.Models;
using ApiRest.Models.Response;
using ApiRest.Repositories.Implementation;
using ApiRest.Repositories.Interface.Base;
using ApiRest.Services.Implementation;
using ApiRest.Services.Interface.Base;
using ApiRest.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

BaseSettings baseSettings = builder.Configuration.Get<BaseSettings>();

#region Injections

//Middleware
builder.Services.AddTransient<ExceptionMiddleware>();

//Database
builder.Services.AddDbContext<CustomContext>(options =>
    options.UseNpgsql(baseSettings.ServiceSettings.Database.DbConnectionString));

//Repositories
builder.Services
    .AddTransient<IRepositorieSave<FuelConsumptionRepositoryImpl, FuelConsumptionEntity>,
        FuelConsumptionRepositoryImpl>();
builder.Services
    .AddTransient<IRepositorieSave<EnergyConsumptionRepositoryImpl, EnergyConsumptionEntity>,
        EnergyConsumptionRepositoryImpl>();
builder.Services
    .AddTransient<IRepositorieSave<PetroleumConsumptionRepositoryImpl, PetroleumConsumptionEntity>,
        PetroleumConsumptionRepositoryImpl>();
builder.Services.AddTransient<IRepositorieSave<TravelRepositoryImpl, TravelEntity>, TravelRepositoryImpl>();

builder.Services
    .AddTransient<IRepositoryGetAll<FuelConsumptionRepositoryImpl, FuelConsumptionEntity>,
        FuelConsumptionRepositoryImpl>();
builder.Services
    .AddTransient<IRepositoryGetAll<EnergyConsumptionRepositoryImpl, EnergyConsumptionEntity>,
        EnergyConsumptionRepositoryImpl>();

//Services
builder.Services
    .AddTransient<IServiceSave<PetroleumConsumptionServiceImpl, PetroleumConsumptionRequest, bool>,
        PetroleumConsumptionServiceImpl>();
builder.Services
    .AddTransient<IServiceSave<EnergyConsumptionServiceImpl, EnergyConsumptionRequest, bool>,
        EnergyConsumptionServiceImpl>();
builder.Services
    .AddTransient<IServiceSave<FuelConsumptionServiceImpl, FuelConsumptionRequest, bool>,
        FuelConsumptionServiceImpl>();

builder.Services.AddTransient<IServiceSave<TravelServiceImpl, TravelRequest, bool>, TravelServiceImpl>();

builder.Services
    .AddTransient<IServiceGet<FuelConsumptionServiceImpl, FuelPercentageResponse>, FuelConsumptionServiceImpl>();
builder.Services
    .AddTransient<IServiceGet<EnergyConsumptionServiceImpl, FuelPercentageBody>, EnergyConsumptionServiceImpl>();
builder.Services
    .AddTransient<IServiceGet<FuelConsumptionServiceImpl, FuelAverageResponse>, FuelConsumptionServiceImpl>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();
app.Run();