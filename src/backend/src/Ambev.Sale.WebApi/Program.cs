
using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Domain.Service;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Infrastructure.ORM;
using Ambev.Sale.Infrastructure.Repository;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Ambev.Sale.Core.Domain.Messaging;
using Ambev.Sale.Infrastructure.Config;
using Ambev.Sale.Core.Application.Sales.Modify;
using Ambev.Sale.Core.Application.Sales.Get;
using Ambev.Sale.Core.Application.Sales.GetList;
using Ambev.Sale.Core.Application.SalesItem.Get;
using Ambev.Sale.Core.Application.SaleItem.Cancel;
using Rebus.Logging;
using Serilog;
using Ambev.Sale.Core.Application;
using Ambev.DeveloperEvaluation.IoC;

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(5000);
    });

    builder.RegisterDependencies();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssemblies(
            typeof(ApplicationLayer).Assembly,
            typeof(Program).Assembly
        );
    });


    builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);


    var app = builder.Build();

    app.Services.GetRequiredService<Rebus.Bus.IBus>();

    //if (app.Environment.IsDevelopment())
    //{
    app.UseSwagger();
    app.UseSwaggerUI();
    //}

    app.UseRouting();
    app.MapGet("/", () => "API run...");

    app.UseCors(cors => cors
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin()
    );

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
