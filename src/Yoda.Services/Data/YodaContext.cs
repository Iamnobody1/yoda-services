using Microsoft.EntityFrameworkCore;
using Yoda.Services.Entities;

namespace Yoda.Services.Data
{
    public class YodaContext : DbContext
    {
        public YodaContext(DbContextOptions<YodaContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetailEntity>().ToTable("OrderDetail");
        }
    }
}
