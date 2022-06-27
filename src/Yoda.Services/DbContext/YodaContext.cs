using Microsoft.EntityFrameworkCore;
using Yoda.Services.Entities;

namespace Yoda.Services.Data;

public class YodaContext : DbContext
{
    public YodaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderDetailEntity> OrderDetails { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProvinceEntity>Province { get; set; }
    public DbSet<DistrictEntity>Districts{ get; set; }
    public DbSet<CountryEntity>Country{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerEntity>(e =>
        {
            e.ToTable("Customer");
        });

        modelBuilder.Entity<OrderEntity>(e =>
        {
            e.ToTable("Order");
            e.HasOne(p => p.Customer).WithMany(b => b.Orders);
        });

        modelBuilder.Entity<OrderDetailEntity>(e =>
        {
            e.ToTable("OrderDetail");
            e.HasOne(p => p.Product).WithMany(b => b.OrderDetails);
            e.HasOne(p => p.Order).WithMany(b => b.OrderDetails);
        });

        modelBuilder.Entity<ProductEntity>(e =>
        {
            e.ToTable("Product");
        });

        modelBuilder.Entity<CountryEntity>(e =>
        {
            e.ToTable("Country");
        });

        modelBuilder.Entity<ProvinceEntity>(e =>
        {
            e.ToTable("Province");
            e.HasOne(p => p.Country).WithMany(b => b.Provinces);
        });

        modelBuilder.Entity<DistrictEntity>(e =>
        {
            e.ToTable("District");
            e.HasOne(p => p.Province).WithMany(b => b.Districts);
        });
    }
}
