
using Application.Layer.DTOs;
using Application.Layer.Interfaces;
using Application.Layer.Services;
using Domain.Layer.DTOs;
using Domain.Layer.Entities;
using Domain.Layer.Models;
using InterfaceAdapter.Layer.DataContext;
using InterfaceAdapter.Layer.Respositories;
using Microsoft.EntityFrameworkCore;
using RaceStrategyManagerService.Constants;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(Constants.DEFAULT_CONNECTION)));



#region ID
builder.Services.AddScoped<IRepository<ApiKeysEntity>, ApiKeysRepository>();
builder.Services.AddScoped<ApiKeysService<ApiKeysEntity>>();

builder.Services.AddScoped<IRepository<ClientsEntity>, ClientsRepository>();
builder.Services.AddScoped<ClientsService<ClientsEntity>>();

builder.Services.AddScoped<IRepository<PilotsEntity>, PilotsRespository>();
builder.Services.AddScoped<IModelResult<PilotsModel>, ResultDTO<PilotsModel>>();
builder.Services.AddScoped<PilotsService<PilotsEntity>>();

builder.Services.AddScoped<IRepository<StrategiesEntity>, StrategiesRepository>();
builder.Services.AddScoped<IModelResult<StrategiesModel>, ResultDTO<StrategiesModel>>();;
builder.Services.AddScoped<StrategiesService<StrategiesEntity>>();

builder.Services.AddScoped<IRepository<TiresEntity>, TiresRepository>();
builder.Services.AddScoped<IModelResult<TiresModel>, ResultDTO<TiresModel>>();
builder.Services.AddScoped<TiresService<TiresEntity>>();
#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//        builder =>
//        {
//            builder.WithOrigins("http://localhost",
//                "http://localhost:4200",
//                "https://localhost:7230",
//                "http://localhost:90")
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .SetIsOriginAllowedToAllowWildcardSubdomains();
//        });
//});



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

app.Run();
