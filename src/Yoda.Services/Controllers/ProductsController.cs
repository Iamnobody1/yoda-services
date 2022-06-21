using Microsoft.AspNetCore.Mvc;
using Yoda.Service2.Models;
using Yoda.Service2.Services.Product;

namespace Yoda.Service2.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int start, [FromQuery] int length)
    {
        var item = _productService.GetList(start, length);
        if (item == null || !item.Any())
            return NotFound();
        return Ok(item);
    }

    [HttpGet("{productId}")]
    public IActionResult Get([FromRoute] int productId)
    {
        var item = _productService.GetById(productId);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ProductModel product)
    {
        var item = _productService.Create(product);
        return Ok(item);
    }

    [HttpPut("{productId}")]
    public IActionResult Put([FromRoute] int productId, [FromBody] ProductModel product)
    {
        _productService.Update(productId, product);
        return Ok();
    }

    [HttpDelete("{productId}")]
    public IActionResult Delete([FromRoute] int productId)
    {
        _productService.Delete(productId);
        return NoContent();
    }
}
