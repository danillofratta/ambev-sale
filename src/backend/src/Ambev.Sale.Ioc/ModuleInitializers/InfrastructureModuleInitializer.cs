using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Domain.Messaging;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Core.Domain.Service;
using Ambev.Sale.Infrastructure.Config;
using Ambev.Sale.Infrastructure.ORM;
using Ambev.Sale.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        //Get RabbitMQ connection string
        //var rabbitMqConnection = GetRabbitMQConnectionString(builder);
        var rabbitMqConnection = builder.Configuration.GetConnectionString("RabbitMQ");
        Console.WriteLine(rabbitMqConnection);
        builder.Services.AddRebusInfrastructure(rabbitMqConnection);
        builder.Services.AutoRegisterHandlersFromAssemblyOf<CreateSaleLogRebusHandler>();
        builder.Services.AddScoped<IMessageBus, MessageBus>();

        //entity config
        builder.Services.AddDbContext<DefaultDbContext>();

        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
        builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
        builder.Services.AddScoped<SaleDiscountService>();
    }

    //TODO
    private string GetRabbitMQConnectionString(WebApplicationBuilder builder)
    {
        // Prioriza variável de ambiente do Docker
        var dockerHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
        if (!string.IsNullOrEmpty(dockerHost))
        {
            return $"amqp://guest:guest@{dockerHost}/";
        }

        // Caso contrário, usa a configuração do appsettings
        var connectionString = builder.Configuration.GetConnectionString("RabbitMQ");
        if (!string.IsNullOrEmpty(connectionString))
        {
            return connectionString;
        }

        // Fallback para localhost
        return "amqp://guest:guest@localhost:5672/";
    }
}