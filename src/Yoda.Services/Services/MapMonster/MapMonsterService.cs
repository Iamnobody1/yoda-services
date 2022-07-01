using AutoMapper;
using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.MapMonster;

public class MapMonsterService  : IMapMonsterService
{
    private readonly YodaContext _yodaContext;
    private readonly IMapper _mapper;

public MapMonsterService(YodaContext yodaContext, IMapper mapper)
{
        _yodaContext = yodaContext;
        _mapper = mapper;
    }

    public int Create(MapMonsterModel mapMonster)
    {
        var item = _mapper.Map<MapMonsterEntity>(mapMonster);
        _yodaContext.MapMonsters.Add(item);
        _yodaContext.SaveChanges();
        return item.Id;
    }

    public void Update(int Id, MapMonsterEntity newMapMonter)
    {
        var item = _yodaContext.MapMonsters.FirstOrDefault(s => s.Id == Id);
        if(item != null)
        {
            item.MapId = newMapMonter.MapId;
            item.MonsterId = newMapMonter.MonsterId;
            item.PositionX = newMapMonter.PositionX;
            item.PositionY = newMapMonter.PositionY;
            item.Facing = newMapMonter.Facing;
            item.CurrentHealth = newMapMonter.CurrentHealth;
            _yodaContext.MapMonsters.Update(item);
            _yodaContext.SaveChanges();
        }
    }

    public void Delete(int Id)
    {
        var item = _yodaContext.MapMonsters.FirstOrDefault(s => s.Id == Id);
        if(item != null)
        {
            _yodaContext.MapMonsters.Remove(item);
            _yodaContext.SaveChanges();
        }
    }
}
