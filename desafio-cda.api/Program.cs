using desafio_cda.api.Repositories.Context;
using desafio_cda.api.Repositories.Implementations;
using desafio_cda.api.Repositories.Interfaces;
using desafio_cda.api.Services.Implementations;
using desafio_cda.api.Services.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.OpenApi.Models;

using AppContext = desafio_cda.api.Repositories.Context.AppDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config =>
{
  config.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1", Description = "My API Swagger" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnString"));
});

builder.Services.AddTransient<ICriminalCodeRepository, CriminalCodeRepository>();
builder.Services.AddTransient<ICriminalCodeService, CriminalCodeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapSwagger();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
