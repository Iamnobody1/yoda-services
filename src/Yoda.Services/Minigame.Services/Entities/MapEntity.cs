using Microsoft.EntityFrameworkCore;

namespace Yoda.Services.Entities;

public class MapEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BackgroundImage { get; set; }

    public IEnumerable<MapMonsterEntity> MapMonsters { get; set; }
}

