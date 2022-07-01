using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Monster
{
    public interface IMonsterService
    {
        public IEnumerable<MonsterModel> GetListMonster(int id);
        int Create(MonsterModel monster);
        void Update(int id, MonsterEntity mon);
        void Delete(int id);

    }
}
