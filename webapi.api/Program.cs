using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using webapi.api;
using Microsoft.EntityFrameworkCore;
using WebApi.Middleware;
using webapi.data;
using webapi.data.Repositorios;
using webapi.data.Repositorios.Implementaciones;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

//SQL
var connectionString = builder.Configuration.GetConnectionString("ConexionDesarmDatacenter");
builder.Services.AddDbContext<DesarmDatacenterContext>(opts => opts.UseSqlServer(connectionString));
builder.Services.AddScoped<DesarmDatacenterContext>();

//Logger
Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc
.ReadFrom.Configuration(ctx.Configuration)));

//Repository
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));

//Unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//CORS
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
          
builder.Services.AddMvc()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize);

//Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Desarm", Version = "v1" });
});


var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("CORSPolicy");
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desarm V1");
});

app.Run();