using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Map
{
    public interface IMap
    {
        public IEnumerable<MapModel> GetMapId(int id);
    }
}
