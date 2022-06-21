using Microsoft.EntityFrameworkCore;
using Yoda.Services.Entities;

namespace Yoda.Services.Data;

public class YodaContext : DbContext
{
    public YodaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderDetailEntity> OrderDetails { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<UserEntity> Users { get; set; }

}
