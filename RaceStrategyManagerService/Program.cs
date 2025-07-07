
using Application.Layer.DTOs;
using Application.Layer.Interfaces;
using Application.Layer.Services;
using Domain.Layer.DTOs;
using Domain.Layer.Entities;
using Domain.Layer.Models;
using InterfaceAdapter.Layer.DataContext;
using InterfaceAdapter.Layer.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RaceStrategyManagerService.Constants;


var builder = WebApplication.CreateBuilder(args);
const string API_KEY = "RacerManagerApiKey";
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200") // Puerto de Angular
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

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
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Ingrese su API Key en el campo X-API-KEY",
        In = ParameterLocation.Header,
        Name = "X-API-KEY",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();
app.UseCors("AllowLocalhost");
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey) ||
        extractedApiKey != API_KEY)
    {
        context.Response.StatusCode = 401; // No autorizado
        await context.Response.WriteAsync("API Key faltante o invalida.");
        return;
    }
    await next();
});

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
