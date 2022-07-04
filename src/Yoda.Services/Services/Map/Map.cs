using Yoda.Services.Data;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Map
{
    public class Map : IMap
    {
        private readonly YodaContext _yodaContext;

        public Map(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }

        public IEnumerable<MapModel> GetMapId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
