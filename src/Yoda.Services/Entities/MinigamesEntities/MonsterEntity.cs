using Microsoft.EntityFrameworkCore;

namespace Yoda.Services.Entities;

public class MonsterEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public string Sprite { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
    public float RespawnTime { get; set; }

    public IEnumerable<MapMonsterEntity> MapMonsters { get; set; }
}

