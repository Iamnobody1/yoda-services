using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Map
{
    public interface IMapService
    {
        Task<int> CreateAsync(MapModel Map);
        Task Delete(int id);
        Task<MapModel> GetMapById(int id);
        Task Update(int id, MapModel map);
    }
}
