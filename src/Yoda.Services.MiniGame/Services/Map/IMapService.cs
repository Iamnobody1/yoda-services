using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Map
{
    public interface IMapService
    {
        int Create(MapModel Map);
        void Delete(int id);
        MapModel GetMapById(int id);
        void Update(int id, MapEntity mon);
    }
}
