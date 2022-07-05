using AutoMapper;
using Yoda.Services.MiniGame.Data;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Monster
{
    public class MonsterService : IMonsterService
    {
        private readonly IMapper _mapper;
        private readonly MinigameContext _minigameContext;

        public MonsterService(IMapper mapper, MinigameContext minigameContext)
        {
            _mapper = mapper;
            _minigameContext = minigameContext;
        }

        public MonsterModel GetMonsterById(int id)
        {
            var item = _minigameContext.Monsters.FirstOrDefault(m => m.Id == id);
            if (item == null)
                return null;
            return _mapper.Map<MonsterModel>(item);
        }

        public int Create(MonsterModel monster)
        {
            var item = _mapper.Map<MonsterEntity>(monster);
            _minigameContext.Monsters.Add(item);
            _minigameContext.SaveChanges();
            return item.Id;
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

        public void Delete(int id)
        {
            var item = _minigameContext.Monsters.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                _minigameContext.Monsters.Remove(item);
                _minigameContext.SaveChanges();
            }
        }
    }
}
