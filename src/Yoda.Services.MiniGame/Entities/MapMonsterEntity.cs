namespace Yoda.Services.MiniGame.Entities;

public class MapMonsterEntity
{
    public int Id { get; set; }
    public int MapId { get; set; }
    public int MonsterId { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int CurrentHealth { get; set; }
    public string Facing { get; set; }

    public MapEntity Map { get; set; }
    public MonsterEntity Monster { get; set; }
}

