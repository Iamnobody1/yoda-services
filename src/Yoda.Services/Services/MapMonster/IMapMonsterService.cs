using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.MapMonster;

public interface IMapMonsterService
{
    IEnumerable<MapMonsterDetailModel> GetMonsters(int mapId);
    int Create(MapMonsterModel mapMonster);
    void Update(int Id, MapMonsterEntity newMapMonter);
    void Delete(int Id);
}

