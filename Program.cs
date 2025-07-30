using Microsoft.EntityFrameworkCore;
using Npgsql;
using RMS.Dependency;
using System.Data;
using System;
using RMS.Dal;
using System.Text.Json.Serialization;
using AutoMapper;
using RMS.Helpers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRmsDependencies();

builder.Services.AddDbContext<RmsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnection"),
    //options => options.CommandTimeout(999)
    options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null)
), ServiceLifetime.Scoped);

builder.Services.AddHttpClient();

builder.Services.AddScoped<IDbConnection>(sp =>
        new NpgsqlConnection(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddHealthChecks();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(cfg => { }, typeof(MapperClass));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("RestrictedPolicy", policy =>
        policy.WithOrigins(
                "https://train-ifms.wb.gov.in",
                "https://ifms.wb.gov.in")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());

    options.AddPolicy("AllowAllPolicy", policy =>
        policy.SetIsOriginAllowed(_ => true)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

var app = builder.Build();

// Use CORS based on environment
app.UseCors(app.Environment.IsDevelopment() ? "AllowAllPolicy" : "RestrictedPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

