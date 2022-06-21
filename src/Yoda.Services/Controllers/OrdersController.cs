using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Entities;
using Yoda.Services.Models;
using Yoda.Services.Services.Order;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService OrderService;

    public OrdersController(IOrderService orderService)
    {
        OrderService = orderService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int start = 0, [FromQuery] int length = 10)
    {
        var result = OrderService.Get(start, length);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{orderId}")]
    public IActionResult Get([FromRoute] int orderId)
    {
        var result = OrderService.GetById(orderId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost()]
    public IActionResult Post([FromBody] OrderModel order)
    {
        var result = OrderService.Create(order);
        return Ok(result);
    }

    [HttpPut("{orderId}")]
    public IActionResult Put([FromRoute] int orderId, [FromBody] OrderEntity order)
    {
        OrderService.Update(orderId, order);
        return Ok();
    }

    [HttpDelete("{orderId}")]
    public IActionResult Delete([FromRoute] int orderId)
    {
        OrderService.Delete(orderId);
        return NoContent();
    }
}
