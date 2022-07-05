using AutoMapper;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.MapperProfile;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressModel, AddressEntity>();
    }
}
