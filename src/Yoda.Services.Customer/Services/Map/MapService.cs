using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Models;
using Yoda.Services.Entities;

namespace Yoda.Services.Services.Map
{
    public class MapService : IMapService
    {
        private readonly YodaContext _yodaContext;
        private readonly IMapper _mapper;

        public MapService(YodaContext yodaContext, IMapper mapper)
        {
            _yodaContext = yodaContext;
            _mapper = mapper;
        }

        public int Create(MapModel mapModel)
        {
            var item = _mapper.Map<MapEntity>(mapModel);
            _yodaContext.Maps?.Add(item);
            _yodaContext.SaveChanges();
            return item.Id;
        }

        public void Delete(int id)
        {
            var result = _yodaContext.Maps?.FirstOrDefault(map => map.Id == id);
            if (result != null)
            {
                _yodaContext.Maps?.Remove(result);
                _yodaContext.SaveChanges();
            }
        }

        public IEnumerable<MapModel> GetList(int start = 0, int length = 10)
        {
            var result = _yodaContext.Maps?.AsNoTracking().Skip(start).Take(length).ToList();
            if (result == null)
                return null;
            return _yodaContext.Maps?.Select(item => new MapModel()
            {
                Id = item.Id,
                Name = item.Name
            });
        }

        public IEnumerable<MapModel> GetMapId(int id)
        {
            var map = _yodaContext.Maps?.AsNoTracking().FirstOrDefault(item => item.Id == id);
            if (map == null)
                return null;
            return _yodaContext.Maps?.Select(item => new MapModel()
            {
                Id = map.Id,
                Name = map.Name
            });
        }

        public void Update(int id, MapModel mapModel)
        {
            var result = _yodaContext.Maps?.FirstOrDefault(map => map.Id == id);
            if (result != null)
            {
                result.Id = mapModel.Id;
                result.Name = mapModel.Name;
                result.BackgroundImage = mapModel.BackgroundImage;
                _yodaContext.SaveChanges();
            }
        }
    }
}

