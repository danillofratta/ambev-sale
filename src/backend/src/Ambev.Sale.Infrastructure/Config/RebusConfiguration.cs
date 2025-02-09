using Ambev.Sale.Core.Application.Sales.Create;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;
using Rebus.Routing.TypeBased;


namespace Ambev.Sale.Infrastructure.Config
{
    public static class RebusConfiguration
    {
        public static void AddRebusInfrastructure(this IServiceCollection services, string connectionString)
        {
            // Registra os handlers do Rebus
            //services.AddRebusHandler<CreateSaleLogRebusHandler>();

            //services.AddRebus((configure, provider) => configure
            //    .Transport(t => t.UseRabbitMq(rabbitMqConnection, "sales_event_queue"))
            //    .Routing(r =>
            //    {
            //        var routing = r.TypeBased();
            //        ConfigureRoutes(routing);                    
            //    }));

            //return services;
            services.AddRebus(configure => configure
                .Transport(t => t.UseRabbitMq(connectionString, "sales_event_queue"))
                .Routing(r => r.TypeBased()
                    .Map<CreateSaleCommand>("sales_command_queue")
                    .Map<CreateSaleEvent>("sales_event_queue"))
                .Options(o =>
                {
                    o.SetNumberOfWorkers(1);
                    o.SetMaxParallelism(1);
                    o.LogPipeline(verbose: true);
                }));
        }

        private static void ConfigureRoutes(TypeBasedRouterConfigurationExtensions.TypeBasedRouterConfigurationBuilder routing)
        {
            routing
                .Map<CreateSaleCommand>("sales_command_queue")
                .Map<CreateSaleEvent>("sales_event_queue");
        }
    }
}
