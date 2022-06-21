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
            e.HasOne(p => p.Order).WithOne(b => b.OrderDetail);
        });

        modelBuilder.Entity<ProductEntity>(e =>
        {
            e.ToTable("Product");
        });
    }
}
