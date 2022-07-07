using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yoda.Services.MiniGame.Data;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Map;

public class MapService : IMapService
{
    private readonly IMapper _mapper;
    private readonly MinigameContext _minigameContext;

    public MapService(IMapper mapper, MinigameContext minigameContext)
    {
        _mapper = mapper;
        _minigameContext = minigameContext;
    }

    public async Task<MapModel> GetMapById(int mapId)
    {
        var item = await _minigameContext.Maps.FirstOrDefaultAsync(m => m.Id == mapId);
        if (item == null)
            return null;
        return _mapper.Map<MapModel>(item);
    }

    public async Task<int> Create(MapModel Map)
    {
        var item = _mapper.Map<MapEntity>(Map);
        await _minigameContext.Maps.AddAsync(item);
        await _minigameContext.SaveChangesAsync();
        return item.Id;
    }

    public async Task Update(int mapId, MapModel map)
    {
        map.Id = mapId;
        var item = await _minigameContext.Maps.FirstOrDefaultAsync(u => u.Id == map.Id);
        if (item != null)
        {
            var x = _mapper.Map<MapModel, MapEntity>(map, item);
            _minigameContext.Maps.Attach(item);
            await _minigameContext.SaveChangesAsync();
        }
    }

    public async Task Delete(int mapId)
    {
        var item = await _minigameContext.Maps.FirstOrDefaultAsync(d => d.Id == mapId);
        if (item != null)
        {
            _minigameContext.Maps.Remove(item);
            await _minigameContext.SaveChangesAsync();
        }
    }
}
