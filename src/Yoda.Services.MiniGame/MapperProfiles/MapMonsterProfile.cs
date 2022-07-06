using AutoMapper;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;

namespace Yoda.Services.MiniGame.MapperProfile;

public class MapMonsterProfile : Profile
{
    public MapMonsterProfile()
    {
        CreateMap<MapMonsterModel, MapMonsterEntity>()
        .ReverseMap();
        CreateMap<MapMonsterEntity, MapMonsterDetailModel>().IncludeMembers(s => s.Monster)
        .ForMember(dest => dest.Monster, opt => opt.MapFrom(src => src.Monster));
    }
}
