using AutoMapper;
using Yoda.Services.
using Yoda.Services.Models;

namespace Yoda.Services.MapperProfile;

public class MapMonsterProfile : Profile
{
    public MapMonsterProfile()
    {
        CreateMap<MapMonsterModel, MapMonsterEntity>().ReverseMap();
    }
}
