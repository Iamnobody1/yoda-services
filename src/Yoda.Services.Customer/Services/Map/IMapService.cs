using Yoda.Services.Models;

namespace Yoda.Services.Services.Map
{
    public interface IMapService
    {
        public int Create(MapModel mapModel);
        IEnumerable<MapModel> GetList(int start = 0, int length = 10);
        public IEnumerable<MapModel> GetMapId(int id);
        void Update(int id, MapModel mapModel);
        void Delete(int id);
    }
}
