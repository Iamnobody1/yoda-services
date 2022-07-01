using AutoMapper;
using Yoda.Services.Entities;

namespace Yoda.Services.Models
{
    public class MonsterProfile : Profile
    {
        public MonsterProfile()
        {
            CreateMap<MonsterModel, MonsterEntity>();
        }
    }
}
