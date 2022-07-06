using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.MapMonster;

public interface IMapMonsterService
{
    Task<int> Create(MapMonsterModel mapMonster);
    Task DecrementHealth(int mapMonsterId, int value);
    Task Delete(int Id);
    Task<MapMonsterDetailModel> GetMonster(int mapMonsterId);
    Task<IEnumerable<MapMonsterDetailModel>> GetMonsters(int mapId);
    Task Update(int id, MapMonsterModel mapMonster);
}
