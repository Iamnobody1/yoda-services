using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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

    public MapMonsterDetailModel GetMonster(int mapMonsterId)
    {
        var item = _minigameContext.MapMonsters
            .AsNoTracking()
            .ProjectTo<MapMonsterDetailModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault(m => m.Id == mapMonsterId);

        if (item == null)
            return null;
        return null;
    }

    public IEnumerable<MapMonsterDetailModel> GetMonsters(int mapId)
    {
        var item = _minigameContext.MapMonsters
            .Where(m => m.Id == mapId)
            .ToList();

        if (item == null)
            return null;
        return _mapper.Map<IEnumerable<MapMonsterDetailModel>>(item);
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
