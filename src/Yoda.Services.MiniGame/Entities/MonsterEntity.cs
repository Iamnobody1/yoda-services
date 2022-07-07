namespace Yoda.Services.MiniGame.Entities;

public class MonsterEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Sprite { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Health { get; set; }
    public int RespawnTime { get; set; }

    public IEnumerable<MapMonsterEntity> MapMonsters { get; set; }
}

