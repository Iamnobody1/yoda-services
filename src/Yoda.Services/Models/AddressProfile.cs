using AutoMapper;
using Yoda.Services.Entities;

namespace Yoda.Services.Models
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressModel, AddressEntity>();
        }
    }
}
