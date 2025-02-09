
using Microsoft.EntityFrameworkCore;
using Ambev.Sale.Core.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Ambev.Sale.Infrastructure.ORM;

public class DefaultDbContext : DbContext
{
    private readonly ILogger<DefaultDbContext> _logger;

    public DefaultDbContext(
               DbContextOptions<DefaultDbContext> options,
               ILogger<DefaultDbContext> logger) : base(options)
    {
        _logger = logger;
    }

    public DbSet<Ambev.Sale.Core.Domain.Entities.Sale> Sales { get; set; }
    public DbSet<Ambev.Sale.Core.Domain.Entities.SaleItem> SaleItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //todo clear code
            //var conn = "server=localhost;user id=root; password=admin; database=ambev;persist security info=true;CharSet=utf8;Port=3306;";
            //optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

            //docker mysql
            //var conn = "server=host.docker.internal;user id=root; password=admin; database=ambev;persist security info=true;CharSet=utf8;Port=3306;";
            //optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

            //docker postgres                
            //var conn = "Host=postgres_db;Port=5432;Username=admin;Password=root;Database=ambev;";        

            //todo remove from here and put appsettings, this os only to fast test
#if DEBUG
            //run docker with VS
            //todo craete appsettings
            var conn = "Host=localhost;Port=5432;Username=admin;Password=root;Database=ambev;";
        optionsBuilder.UseNpgsql(conn);
#else
        //run docker 
        //todo craete appsettings
        var conn = "Host=postgres_db;Port=5432;Username=admin;Password=root;Database=ambev;";
        optionsBuilder.UseNpgsql(conn);
#endif
            _logger.LogWarning("DbContext being created");            
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ambev.Sale.Core.Domain.Entities.Sale>()
            .HasMany(s => s.SaleItems)
            .WithOne(si => si.Sale)
            .HasForeignKey(si => si.SaleId);
    }
}


