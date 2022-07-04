using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Monster
{
    public interface IMonsterService
    {
        MonsterModel GetMonsterId(int id);
        int Create(MonsterModel monster);
        void Update(int id, MonsterEntity mon);
        void Delete(int id);

    }
}
