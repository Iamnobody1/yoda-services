using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Monster
{
    public class MonsterService : IMonsterService
    {
        private readonly MinigameContext _minigameContext;
        private readonly IMapper _mapper;

        public MonsterService(MinigameContext minigameContext, IMapper mapper)
        {
            _minigameContext = minigameContext;
            _mapper = mapper;
        }

        public int Create(MonsterModel monster)
        {
            var item = _mapper.Map<MonsterEntity>(monster);
            _minigameContext.Monsters.Add(item);
            _minigameContext.SaveChanges();
            return item.Id;
        }

        public void Delete(int id)
        {
            var item = _minigameContext.Monsters.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                _minigameContext.Monsters.Remove(item);
                _minigameContext.SaveChanges();
            }
        }

        public MonsterModel GetMonsterId(int id)
        {
            var item = _minigameContext.Monsters.FirstOrDefault(m => m.Id == id);
            if (item == null)
                return null;
            return _mapper.Map<MonsterModel>(item);

        }

        public void Update(int id, MonsterEntity mon)
        {
            var item = _minigameContext.Monsters.FirstOrDefault(u => u.Id == id);
            if (item != null)
            {
                item.Name = mon.Name;
                item.Health = mon.Health;
                item.Sprite = mon.Sprite;
                item.Width = mon.Width;
                item.Height = mon.Height;
                item.RespawnTime = mon.RespawnTime;
                _minigameContext.SaveChanges();
            }
        }
    }
}
