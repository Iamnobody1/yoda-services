using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Services.Order;

namespace Yoda.Services.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerOrdersController : ControllerBase
{
    private readonly IOrderService _orderservice;

    public CustomerOrdersController(IOrderService orderservice)
    {
        _orderservice = orderservice;
    }

    [HttpGet("{customerId}")]
    public IActionResult Get([FromRoute] int customerId)
    {
        var result = _orderservice.GetOrdersOfCustomer(customerId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
