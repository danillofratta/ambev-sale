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

        //rebus config
        var conn = builder.Configuration.GetSection("ConnectionStrings").Get<Dictionary<string, string>>();
        builder.Services.AddRebusInfrastructure(conn["RabbitMQ"]);
        //todo everything since I switched to ioc is not getting release when compiling in docker
        //todo and docker dont find correct connection
        //#if DEBUG
        //        builder.Services.AddRebusInfrastructure("amqp://localhost");
        //        Console.WriteLine("debug");
        //#else
        //        builder.Services.AddRebusInfrastructure("amqp://guest:guest@rabbitmq:5672");
        //        Console.WriteLine("release");
        //#endif

        builder.Services.AutoRegisterHandlersFromAssemblyOf<CreateSaleLogRebusHandler>();
        builder.Services.AddScoped<IMessageBus, MessageBus>();

        //entity config
        builder.Services.AddDbContext<DefaultDbContext>();

        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
        builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
        builder.Services.AddScoped<SaleDiscountService>();
    }
}