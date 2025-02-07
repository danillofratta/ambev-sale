using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Ambev.Sale.Core.Domain.Repository;
using System.Reflection;
using AutoMapper;
using Ambev.Sale.Core.Application.Sales.Create;
using System;
using Ambev.Sale.Core.Domain.Service;
using Ambev.Sale.Infrastructure.ORN;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // HTTP
    //options.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // HTTPS
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateSaleHandler).Assembly,
        //typeof(CreateSaleResult).Assembly,
        typeof(Program).Assembly
    );
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<DefaultDbContext>();

builder.Services.AddScoped<SaleRepository>();
builder.Services.AddScoped<SaleItemRepository>();
builder.Services.AddScoped<SaleDiscountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseRouting();
app.MapGet("/", () => "API rodando...");

app.UseCors(cors => cors
.AllowAnyMethod()
.AllowAnyHeader()
.AllowAnyOrigin()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
