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

    public async Task<MapMonsterDetailModel> GetMonster(int mapMonsterId)
    {
        var item = await _minigameContext.MapMonsters
            .AsNoTracking()
            .ProjectTo<MapMonsterDetailModel>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(m => m.Id == mapMonsterId);

        if (item == null)
            return null;
        return item;
    }

    public async Task<IEnumerable<MapMonsterDetailModel>> GetMonsters(int mapId)
    {
        var item = await _minigameContext.MapMonsters
            .Where(m => m.Id == mapId)
            .ToListAsync();

        if (item == null)
            return null;
        return _mapper.Map<IEnumerable<MapMonsterDetailModel>>(item);
    }

    public async Task<int> Create(MapMonsterModel mapMonster)
    {
        var item = _mapper.Map<MapMonsterEntity>(mapMonster);
        await _minigameContext.MapMonsters.AddAsync(item);
        await _minigameContext.SaveChangesAsync();

        return item.Id;
    }

    public async Task Update(int id, MapMonsterModel mapMonster)
    {
        mapMonster.Id = id;
        var item = await _minigameContext.MapMonsters.FirstOrDefaultAsync(s => s.Id == mapMonster.Id);
        if (item != null)
        {
            var x = _mapper.Map<MapMonsterModel, MapMonsterEntity>(mapMonster, item);
            _minigameContext.MapMonsters.Attach(item);
            await _minigameContext.SaveChangesAsync();
        }
    }

    public async Task DecrementHealth(int mapMonsterId, int value)
    {
        var item = await _minigameContext.MapMonsters.FirstOrDefaultAsync(s => s.Id == mapMonsterId);
        if (item != null)
        {
            item.CurrentHealth = item.CurrentHealth - value;
            _minigameContext.MapMonsters.Attach(item);
            await _minigameContext.SaveChangesAsync();
        }
    }

    public async Task Delete(int Id)
    {
        var item = await _minigameContext.MapMonsters.FirstOrDefaultAsync(s => s.Id == Id);
        if (item != null)
        {
            _minigameContext.MapMonsters.Remove(item);
            await _minigameContext.SaveChangesAsync();
        }
    }
}
