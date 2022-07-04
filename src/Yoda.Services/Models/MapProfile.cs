using AutoMapper;
using Yoda.Services.Entities;

namespace Yoda.Services.Models
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MapModel, MapEntity>().ReverseMap();
        }

    }
}
