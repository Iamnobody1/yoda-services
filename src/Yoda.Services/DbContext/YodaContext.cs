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
    public DbSet<DistrictEntity> Districts { get; set; }
    public DbSet<SubDistrictEntity> SubDistricts { get; set; }
    public DbSet<PostalCodeEntity> PostalCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerEntity>(e =>
        {
            e.ToTable("Customer");
        });

        modelBuilder.Entity<DistrictEntity>(e =>
        {
            e.ToTable("District");
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

        modelBuilder.Entity<PostalCodeEntity>(e =>
        {
            e.ToTable("PostalCode");
            e.HasOne(p => p.District).WithMany(b => b.postalCodes);
        });

        modelBuilder.Entity<ProductEntity>(e =>
        {
            e.ToTable("Product");
        });

        modelBuilder.Entity<SubDistrictEntity>(e =>
        {
            e.ToTable("SubDistrict");
            e.HasOne(p => p.District).WithMany(b => b.SubDistricts);
        });
    }
}
