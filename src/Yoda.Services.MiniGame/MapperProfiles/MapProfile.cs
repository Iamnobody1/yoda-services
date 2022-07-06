using AutoMapper;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.MapperProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MapModel, MapEntity>().ReverseMap();
        }
    }
}
