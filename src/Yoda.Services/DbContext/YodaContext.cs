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
        modelBuilder.Entity<OrderEntity>().ToTable("Order");
        modelBuilder.Entity<OrderDetailEntity>().ToTable("OrderDetail");
        modelBuilder.Entity<ProductEntity>().ToTable("Product");
        modelBuilder.Entity<CustomerEntity>().ToTable("Customer");
    }
}
