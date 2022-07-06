using AutoMapper;
using Yoda.Services.MiniGame.Data;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.Services.Map
{

    public class MapService : IMapService
    {
        private readonly IMapper _mapper;
        private readonly MinigameContext _minigameContext;

        public MapService(IMapper mapper, MinigameContext minigameContext)
        {
            _mapper = mapper;
            _minigameContext = minigameContext;
        }

        public MapModel GetMapById(int id)
        {
            var item = _minigameContext.Maps.FirstOrDefault(m => m.Id == id);
            if (item == null)
                return null;
            return _mapper.Map<MapModel>(item);
        }

        public int Create(MapModel Map)
        {
            var item = _mapper.Map<MapEntity>(Map);
            _minigameContext.Maps.Add(item);
            _minigameContext.SaveChanges();
            return item.Id;
        }

        public void Update(int id, MapModel map)
        {
            map.Id = id;
            var item = _minigameContext.Maps.FirstOrDefault(u => u.Id == map.Id);
            if (item != null)
            {
                var x = _mapper.Map<MapModel, MapEntity>(map, item);
                _minigameContext.Maps.Attach(item);
                _minigameContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _minigameContext.Maps.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                _minigameContext.Maps.Remove(item);
                _minigameContext.SaveChanges();
            }
        }
    }
}
