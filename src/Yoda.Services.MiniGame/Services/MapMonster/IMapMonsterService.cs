using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.MapMonster;

public interface IMapMonsterService
{
    int Create(MapMonsterModel mapMonster);
    void DecrementHealth(int mapMonsterId, int value);
    void Delete(int Id);
    MapMonsterDetailModel GetMonster(int mapMonsterId);
    IEnumerable<MapMonsterDetailModel> GetMonsters(int mapId);
    void Update(int id, MapMonsterModel mapMonster);
}
