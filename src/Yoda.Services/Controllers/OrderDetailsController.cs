using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Models;
using Yoda.Services.Services.OrderDetail;
using Yoda.Services.Entities;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailService OrderDetailService;

    public OrderDetailsController(IOrderDetailService orderDetailService)
    {
        OrderDetailService = orderDetailService;
    }

    [HttpGet()]
    public IActionResult Get([FromQuery] int start, [FromQuery] int length)
    {
        var result = OrderDetailService.GetList(start, length);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public IActionResult Get([FromRoute] int Id)
    {
        var result = OrderDetailService.GetById(Id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost()]
    public IActionResult Post([FromBody] OrderDetailModel orderDetail)
    {
        var result = OrderDetailService.Create(orderDetail);
        return Ok(result);
    }
    [HttpPut("{Id}")]
    public IActionResult Put([FromRoute] int Id, [FromBody] OrderDetailEntity orderDetail)
    {
        OrderDetailService.Update(Id, orderDetail);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete([FromRoute] int Id)
    {
        OrderDetailService.Delete(Id);
        return NoContent();
    }
}
