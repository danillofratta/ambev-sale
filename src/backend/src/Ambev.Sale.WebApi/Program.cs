
using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Domain.Service;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Infrastructure.ORM;
using Ambev.Sale.Infrastructure.Repository;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Ambev.Sale.Core.Domain.Messaging;
using Ambev.Sale.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});

//todo add in infrastructure
//todo 
//builder.Services.AddRebus(config => config
//    .Transport(t => t.UseRabbitMq("amqp://localhost", "sales_event_queue"))
//    .Routing(r => r.TypeBased()
//        .Map<CreateSaleCommand>("sales_command_queue")
//        .Map<CreateSaleEvent>("sales_event_queue"))
//);

//builder.Services.AutoRegisterHandlersFromAssemblyOf<CreateSaleLogRebusHandler>();
builder.Services.AddRebusInfrastructure("amqp://localhost");
builder.Services.AddScoped<IMessageBus, MessageBus>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateSaleHandler).Assembly,        
        typeof(Program).Assembly
    );
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DefaultDbContext>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
builder.Services.AddScoped<SaleDiscountService>();

var app = builder.Build();

// Start Rebus correctly
//app.Services.UseRebus();

app.Services.GetRequiredService<Rebus.Bus.IBus>();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

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
