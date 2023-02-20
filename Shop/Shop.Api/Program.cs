using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interface;
using Common.Application.FileUtil.Service;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Products;
using Shop.Config;
using Shop.Domain.ProductAgg.Services;
using Shop.Infrastucture.Persistent.Ef;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.RegisterShopDependency(connectionString);
CommonBootstrapper.Init(builder.Services);
builder.Services.AddTransient<IFileService,FileService>();
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
