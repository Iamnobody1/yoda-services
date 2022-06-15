using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Models;
using Yoda.Services.Services.Customer;
using Yoda.Services.Entities;
namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService CustomerService;

    public CustomersController(ICustomerService customerService)
    {
        CustomerService = customerService;
    }

    [HttpGet()]
    public IActionResult Get([FromQuery] int start, [FromQuery] int lenght)
    {
        CustomerService.GetList(start, lenght);
        return Ok();
    }

    [HttpGet("{Id}")]
    public IActionResult Get([FromRoute] int customerId)
    {
        var result = CustomerService.GetByID(customerId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }


    [HttpPost]
    public IActionResult Post([FromBody] CustomerModel customer)
    {
        var result = CustomerService.Create(customer);
        return Ok(result);
    }

    [HttpPut("{userId}")]
    public IActionResult Put([FromRoute] int customerId, [FromBody] CustomerEntity customer)
    {
        CustomerService.Update(customerId, customer);
        return Ok();
    }

    [HttpDelete("{userId}")]
    public IActionResult Delete([FromRoute] int customerId)
    {
        CustomerService.Delete(customerId);
        return Ok();
    }

}
