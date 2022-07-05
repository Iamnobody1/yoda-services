using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.MapMonster;

public interface IMapMonsterService
{
    IEnumerable<MapMonsterDetailModel> GetMonsters(int mapId);
    int Create(MapMonsterModel mapMonster);
    void Update(int mapMonsterId, MapMonsterEntity newMapMonter);
    void DecrementHealth(int mapMonsterId, int value);
    void Delete(int mapMonsterId);
}

