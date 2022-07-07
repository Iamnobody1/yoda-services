using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Monster
{
    public interface IMonsterService
    {
        Task<int> Create(MonsterModel monster);
        Task Delete(int monsterId);
        Task<MonsterModel> GetMonsterById(int monsterId);
        Task Update(int monsterId, MonsterModel mon);
    }
}
