using Microsoft.EntityFrameworkCore;
using Yoda.Services.Entities;

namespace Yoda.Services.Data;

public class YodaContext : DbContext
{
    public YodaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderEntity> Cats { get; set; }
}
