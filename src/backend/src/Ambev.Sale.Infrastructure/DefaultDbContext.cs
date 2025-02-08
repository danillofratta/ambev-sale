
using Microsoft.EntityFrameworkCore;
using Ambev.Sale.Core.Domain.Entities;

namespace Ambev.Sale.Infrastructure.ORM;

public class DefaultDbContext : DbContext
{

    public DbSet<Ambev.Sale.Core.Domain.Entities.Sale> Sales { get; set; }
    public DbSet<Ambev.Sale.Core.Domain.Entities.SaleItem> SaleItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //var conn = "server=localhost;user id=root; password=admin; database=ambev;persist security info=true;CharSet=utf8;Port=3306;";
        //optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

        //docker mysql
        //var conn = "server=host.docker.internal;user id=root; password=admin; database=ambev;persist security info=true;CharSet=utf8;Port=3306;";
        //optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

        //docker postgres                
        //var conn = "Host=postgres_db;Port=5432;Username=admin;Password=root;Database=ambev;";        

        //todo remove from here and put appsettings, this os only to fast test
        #if DEBUG
        //rodar com docker mas no visual
        var conn = "Host=localhost;Port=5432;Username=admin;Password=root;Database=ambev;";
        optionsBuilder.UseNpgsql(conn);
        #else
        //rodar doker
        var conn = "Host=postgres_db;Port=5432;Username=admin;Password=root;Database=ambev;";
        optionsBuilder.UseNpgsql(conn);
        #endif

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ambev.Sale.Core.Domain.Entities.Sale>()
            .HasMany(s => s.SaleItems)
            .WithOne(si => si.Sale)
            .HasForeignKey(si => si.SaleId);
    }
}

//public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultDbContext>
//{
//    public DefaultDbContext CreateDbContext(string[] args)
//    {
//        IConfigurationRoot configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json")
//            .Build();

//        var builder = new DbContextOptionsBuilder<DefaultDbContext>();
//        var connectionString = configuration.GetConnectionString("DefaultConnection");

//        builder.UseNpgsql(
//               connectionString,
//               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
//        );

//        return new DefaultContext(builder.Options);
//    }
//}


