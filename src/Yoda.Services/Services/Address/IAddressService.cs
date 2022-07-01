using Yoda.Services.Models;

namespace Yoda.Services.Services.Country;

public interface IAddressService
{
    int Create(AddressModel address);
}
