using N_To_N_With_AutoMapper.Services;
using N_To_N_With_AutoMapper.EndPoints;
using N_To_N_With_AutoMapper.Data;
using N_To_N_With_AutoMapper.Repositories;
using N_To_N_With_AutoMapper.Application.Common.Mappings;

using AutoMapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSqlite<BankDbContext>("Data Source=Bank.db");

builder.Services.AddScoped<BankRepository>();

builder.Services.AddScoped<BankService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddOpenApi();

builder.Services.AddScoped<WheaterService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapWeatherForecast();

app.MapBankEndPoint();

app.Run();

