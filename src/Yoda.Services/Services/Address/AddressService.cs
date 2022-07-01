using Yoda.Services.Data;
using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.Country;

public class AddressService : IAddressService
{
    private readonly YodaContext _yodaContext;

    public AddressService(YodaContext yodaContext)
    {
        _yodaContext = yodaContext;
    }

    public void Create(AddressModel newAddress)
    {
        var address = new AddressEntity();
        address.CustomerId = newAddress.CustomerId;
        address.SubDistrictId = newAddress.SubDistrictId;
        address.Address = newAddress.Address;
        address.EnabledFlag = true;
        address.PostalCode = newAddress.PostalCode;
        _yodaContext.Addresses.Add(address);
        _yodaContext.SaveChanges();
    }
}


