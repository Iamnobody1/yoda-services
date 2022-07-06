using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Monster
{
    public interface IMonsterService
    {
        MonsterModel GetMonsterById(int id);
        int Create(MonsterModel monster);
        void Update(int id, MonsterModel mon);
        void Delete(int id);

    }
}
