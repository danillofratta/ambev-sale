
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

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});


//rebus config and register
var conn = builder.Configuration.GetSection("ConnectionStrings").Get<Dictionary<string, string>>();
builder.Services.AddRebusInfrastructure(conn["RabbitMQ"]);
builder.Services.AutoRegisterHandlersFromAssemblyOf<CreateSaleLogRebusHandler>();
builder.Services.AddScoped<IMessageBus, MessageBus>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateSaleHandler).Assembly,
        typeof(CancelSaleHandler).Assembly,
        typeof(GetSaleQueryHandler).Assembly,
        typeof(GetListSaleQueryHandler).Assembly,
        typeof(ModifySaleHandler).Assembly,
        typeof(GetSaleItemQueryHandler).Assembly,
        typeof(CancelSaleItemHandler).Assembly,
        typeof(Program).Assembly
    );
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DefaultDbContext>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
builder.Services.AddScoped<SaleDiscountService>();

var app = builder.Build();

app.Services.GetRequiredService<Rebus.Bus.IBus>();

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
