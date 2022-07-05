using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.MapMonster;

public interface IMapMonsterService
{
    IEnumerable<MapMonsterDetailModel> GetMonsters(int mapId);
    int Create(MapMonsterModel mapMonster);
    void Update(int mapMonsterId, MapMonsterEntity newMapMonter);
    void DecrementHealth(int mapMonsterId, int value);
    void Delete(int mapMonsterId);
}

