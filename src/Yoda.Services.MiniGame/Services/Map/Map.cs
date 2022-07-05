using Yoda.Services.MiniGame.Data;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Map
{
    public class Map : IMap
    {
        private readonly MinigameContext _minigameContext;

        public Map(MinigameContext minigameContext)
        {
            _minigameContext = minigameContext;
        }

        public IEnumerable<MapModel> GetMapId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
