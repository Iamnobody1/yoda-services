using Microsoft.EntityFrameworkCore;
using Yoda.Service2.Entities;

namespace Yoda.Service2.Data
{

    public class YodaContext : DbContext
    {
        public YodaContext(DbContextOptions<YodaContext> options) : base(options)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
