using Yoda.Services.Models;

namespace Yoda.Services.Services.Map
{
    public interface IMap
    {
        public IEnumerable<MapModel> Map(int id);
    }
}
