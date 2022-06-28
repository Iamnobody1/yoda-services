using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Models;
using Yoda.Services.Services.Country;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] AddressModel address)
    {
        _addressService.Create(address);
        return Ok();
    }
}
