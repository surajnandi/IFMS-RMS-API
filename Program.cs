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
using RMS.Middleware;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Reflection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using RMS.Authentication.JWT.Auth;
using RMS.Authentication.JWT.Config;

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

//builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication();

builder.Services.AddAuthorizationPolicies();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "RMS - Version_1.0.0",
            Version = "v1",
            Description = "RMS Web API",
        }
    );
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

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

app.UseHsts();
app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("Server");
    context.Response.Headers.Remove("X-Powered-By");
    context.Response.Headers.Remove("X-AspNet-Version");
    context.Response.Headers.Remove("X-AspNetMvc-Version");
    await next();
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.MapHealthChecks("/healthz");

app.MapGet(
    "/get-version",
    () =>
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
        Process process = Process.GetCurrentProcess();
        return JsonConvert.SerializeObject(
            new
            {
                Version = fileVersionInfo.ProductVersion,
                MemoryUsage = FileSizeFormatter.FormatSize(
                    process.WorkingSet64
                        + process.PagedSystemMemorySize64
                        + GC.GetGCMemoryInfo().TotalCommittedBytes
                        + GC.GetTotalMemory(false)
                ),
            }
        );
    }
);

// Use CORS based on environment
app.UseCors(app.Environment.IsDevelopment() ? "AllowAllPolicy" : "RestrictedPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.InjectStylesheet("/swagger-ui/swagger.css");
        options.InjectJavascript("/swagger-ui/jquery-3.7.1.min.js");
        options.InjectJavascript("/swagger-ui/swagger.js");
        options.EnableFilter();
        options.EnablePersistAuthorization();
        options.EnableValidator();
        options.EnableDeepLinking();
        options.DisplayRequestDuration();
        options.ShowExtensions();
        options.DocumentTitle = "RMS API";
        options.DocExpansion(DocExpansion.None);
    });
}


app.UseStaticFiles();

app.UseDefaultFiles();

app.UseFileServer();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseAuthTokenMiddleware();

app.Run();

