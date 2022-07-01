using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Monster
{
    public class MonsterService : IMonsterService
    {
        private readonly YodaContext _yodaContext;
        private readonly IMapper _mapper;

        public MonsterService(YodaContext yodaContext, IMapper mapper)
        {
            _yodaContext = yodaContext;
            _mapper = mapper;
        }

        public int Create(MonsterModel monster)
        {
            var item = _mapper.Map<MonsterEntity>(monster);
            _yodaContext.Monsters.Add(item);
            _yodaContext.SaveChanges();
            return item.Id;
        }

        public void Delete(int id)
        {
            var item = _yodaContext.Monsters.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                _yodaContext.Monsters.Remove(item);
                _yodaContext.SaveChanges();
            }
        }

        public IEnumerable<MonsterModel> GetListMonster(int id)
        {
            return _yodaContext.Monsters
       .AsNoTracking()
       .Where(item => item.Id == id)
       .Select(mon => new MonsterModel()
       {
           Id = mon.Id,
           Name = mon.Name,
           Health = mon.Health,
           Sprite = mon.Sprite,
           Width = mon.Width,
           Height = mon.Height,
           RespawnTime = mon.RespawnTime

       });
        }

        public void Update(int id, MonsterEntity mon)
        {
            var item = _yodaContext.Monsters.FirstOrDefault(u => u.Id == id);
            if (item != null)
            {
                item.Name = mon.Name;
                item.Health = mon.Health;
                item.Sprite = mon.Sprite;
                item.Width = mon.Width;
                item.Height = mon.Height;
                item.RespawnTime = mon.RespawnTime;
                _yodaContext.SaveChanges();
            }
        }
    }
}
