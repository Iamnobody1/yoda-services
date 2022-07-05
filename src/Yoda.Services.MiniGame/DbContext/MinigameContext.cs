using Microsoft.EntityFrameworkCore;
using Yoda.Services.MiniGame.Entities;

namespace Yoda.Services.MiniGame.Data;

public class MinigameContext : DbContext
{
    public MinigameContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<MapEntity> Maps { get; set; }
    public DbSet<MapMonsterEntity> MapMonsters { get; set; }
    public DbSet<MonsterEntity> Monsters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MapEntity>(e =>
        {
            e.ToTable("Map");
        });

        modelBuilder.Entity<MapMonsterEntity>(e =>
        {
            e.ToTable("MapMonster");
            e.HasOne(p => p.Map).WithMany(b => b.MapMonsters);
            e.HasOne(p => p.Monster).WithMany(b => b.MapMonsters);
        });

        modelBuilder.Entity<MonsterEntity>(e =>
        {
            e.ToTable("Monster");
        });
    }
}

