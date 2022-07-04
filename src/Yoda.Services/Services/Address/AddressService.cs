using AutoMapper;
using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Country;

public class AddressService : IAddressService
{
    private readonly YodaContext _yodaContext;
    private readonly IMapper _mapper;

    public AddressService(YodaContext yodaContext, IMapper mapper)
    {
        _yodaContext = yodaContext;
        _mapper = mapper;
    }

    public int Create(AddressModel address)
    {
        var item = _mapper.Map<AddressEntity>(address);
        _yodaContext.Addresses.Add(item);
        _yodaContext.SaveChanges();
        return item.Id;
    }
}


