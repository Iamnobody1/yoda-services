using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yoda.Services.MiniGame.Data;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Monster;

public class MonsterService : IMonsterService
{
    private readonly IMapper _mapper;
    private readonly MinigameContext _minigameContext;

    public MonsterService(IMapper mapper, MinigameContext minigameContext)
    {
        _mapper = mapper;
        _minigameContext = minigameContext;
    }

    public async Task<MonsterModel> GetMonsterById(int id)
    {
        var item = await _minigameContext.Monsters.FirstOrDefaultAsync(m => m.Id == id);
        if (item == null)
            return null;
        return _mapper.Map<MonsterModel>(item);
    }

    public async Task<int> Create(MonsterModel monster)
    {
        var item = _mapper.Map<MonsterEntity>(monster);
        _minigameContext.Monsters.Add(item);
        await _minigameContext.SaveChangesAsync();
        return item.Id;
    }

    public async Task Update(int id, MonsterModel monster)
    {
        monster.Id = id;
        var item = await _minigameContext.Monsters.FirstOrDefaultAsync(u => u.Id == monster.Id);
        if (item != null)
        {
            var x = _mapper.Map<MonsterModel, MonsterEntity>(monster, item);
            _minigameContext.Monsters.Attach(item);
            await _minigameContext.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var item = await _minigameContext.Monsters.FirstOrDefaultAsync(d => d.Id == id);
        if (item != null)
        {
            _minigameContext.Monsters.Remove(item);
            await _minigameContext.SaveChangesAsync();
        }
    }
}
