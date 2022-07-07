using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Map
{
    public interface IMapService
    {
        Task<int> Create(MapModel map);
        Task Delete(int mapId);
        Task<MapModel> GetMapById(int mapId);
        Task Update(int mapId, MapModel map);
    }
}
