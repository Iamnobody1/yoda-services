using AutoMapper;
using Yoda.Services.MiniGame.Entities;

namespace Yoda.Services.MiniGame.Models
{
    public class MonsterProfile : Profile
    {
        public MonsterProfile()
        {
            CreateMap<MonsterModel, MonsterEntity>()
                .ReverseMap();
        }
    }
}
