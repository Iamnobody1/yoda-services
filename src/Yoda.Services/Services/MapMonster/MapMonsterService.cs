using AutoMapper;
using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.MapMonster;

public class MapMonsterService  : IMapMonsterService
{
    private readonly MinigameContext _mapMonsters;
    private readonly IMapper _mapper;

public MapMonsterService(MinigameContext minigameContext, IMapper mapper)
{
        _mapMonsters = minigameContext;
        _mapper = mapper;
    }

    public int Create(MapMonsterModel mapMonster)
    {
        var item = _mapper.Map<MapMonsterEntity>(mapMonster);
        _mapMonsters.MapMonsters.Add(item);
        _mapMonsters.SaveChanges();
        return item.Id;
    }

    public void Update(int Id, MapMonsterEntity newMapMonter)
    {
        var item = _mapMonsters.MapMonsters.FirstOrDefault(s => s.Id == Id);
        if(item != null)
        {
            item.MapId = newMapMonter.MapId;
            item.MonsterId = newMapMonter.MonsterId;
            item.PositionX = newMapMonter.PositionX;
            item.PositionY = newMapMonter.PositionY;
            item.Facing = newMapMonter.Facing;
            item.CurrentHealth = newMapMonter.CurrentHealth;
            _mapMonsters.MapMonsters.Update(item);
            _mapMonsters.SaveChanges();
        }
    }

    public void Delete(int Id)
    {
        var item = _mapMonsters.MapMonsters.FirstOrDefault(s => s.Id == Id);
        if(item != null)
        {
            _mapMonsters.MapMonsters.Remove(item);
            _mapMonsters.SaveChanges();
        }
    }
}
