using Microsoft.EntityFrameworkCore;

namespace Yoda.Services.Models;

public class MapMonsterModel
{
    public int Id { get; set; }
    public int MapId { get; set; }
    public int MonsterId { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string Facing { get; set; }
    public int CurrentHealth { get; set; }

}

