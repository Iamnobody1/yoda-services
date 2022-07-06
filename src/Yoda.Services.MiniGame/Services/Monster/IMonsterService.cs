using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Monster
{
    public interface IMonsterService
    {
        Task<int> Create(MonsterModel monster);
        Task Delete(int id);
        Task<MonsterModel> GetMonsterById(int id);
        Task Update(int id, MonsterModel mon);
    }
}
