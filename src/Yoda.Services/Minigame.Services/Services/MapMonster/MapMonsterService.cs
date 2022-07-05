using AutoMapper;
using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.MapMonster;

public class MapMonsterService : IMapMonsterService
{
    private readonly IMapper _mapper;
    private readonly MinigameContext _minigameContext;

    public MapMonsterService(IMapper mapper, MinigameContext minigameContext)
    {
        _mapper = mapper;
        _minigameContext = minigameContext;
    }

    public IEnumerable<MapMonsterDetailModel> GetMonsters(int mapId)
    {
        var data = _minigameContext.MapMonsters
            .Where(x => x.MapId == mapId)
            .Select(x => new MapMonsterDetailModel
            {
                Id = x.Id,
                MapId = x.MapId,
                MonsterId = x.MonsterId,
                PositionX = x.PositionX,
                PositionY = x.PositionY,
                Facing = x.Facing,
                CurrentHealth = x.CurrentHealth,
                Monster = new MonsterModel
                {
                    Id = x.Monster.Id,
                    Name = x.Monster.Name,
                    Health = x.Monster.Health,
                    Sprite = x.Monster.Sprite,
                    Width = x.Monster.Width,
                    Height = x.Monster.Height,
                    RespawnTime = x.Monster.RespawnTime,
                }
            })
            .ToList();

        return data;
    }

    public int Create(MapMonsterModel mapMonster)
    {
        var item = _mapper.Map<MapMonsterEntity>(mapMonster);
        _minigameContext.MapMonsters.Add(item);
        _minigameContext.SaveChanges();

        return item.Id;
    }

    public void Update(int mapMonsterId, MapMonsterEntity newMapMonter)
    {
        var item = _minigameContext.MapMonsters.FirstOrDefault(s => s.Id == mapMonsterId);
        if (item != null)
        {
            item.MapId = newMapMonter.MapId;
            item.MonsterId = newMapMonter.MonsterId;
            item.PositionX = newMapMonter.PositionX;
            item.PositionY = newMapMonter.PositionY;
            item.Facing = newMapMonter.Facing;
            item.CurrentHealth = newMapMonter.CurrentHealth;
            _minigameContext.MapMonsters.Update(item);
            _minigameContext.SaveChanges();
        }
    }

    public void DecrementHealth(int mapMonsterId, int value)
    {
        var item = _minigameContext.MapMonsters.FirstOrDefault(s => s.Id == mapMonsterId);
        if (item != null)
        {
            item.CurrentHealth = item.CurrentHealth - value;
            _minigameContext.MapMonsters.Update(item);
            _minigameContext.SaveChanges();
        }
    }

    public void Delete(int Id)
    {
        var item = _minigameContext.MapMonsters.FirstOrDefault(s => s.Id == Id);
        if (item != null)
        {
            _minigameContext.MapMonsters.Remove(item);
            _minigameContext.SaveChanges();
        }
    }
}
