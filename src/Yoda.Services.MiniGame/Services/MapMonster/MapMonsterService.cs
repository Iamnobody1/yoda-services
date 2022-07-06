using AutoMapper;
using Yoda.Services.MiniGame.Data;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.MapMonster;

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

    public void Update(int id, MapMonsterModel mapMonster)
    {
        mapMonster.Id = id;
        var item = _minigameContext.MapMonsters.FirstOrDefault(s => s.Id == mapMonster.Id);
        if (item != null)
        {
            var x = _mapper.Map<MapMonsterModel, MapMonsterEntity>(mapMonster, item);
            _minigameContext.MapMonsters.Attach(item);
            _minigameContext.SaveChanges();
        }
    }

    public void DecrementHealth(int mapMonsterId, int value)
    {
        var item = _minigameContext.MapMonsters.FirstOrDefault(s => s.Id == mapMonsterId);
        if (item != null)
        {
            item.CurrentHealth = item.CurrentHealth - value;
            _minigameContext.MapMonsters.Attach(item);
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
