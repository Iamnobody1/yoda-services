using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Services.Province;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvincesController : ControllerBase
{
    private readonly IProvinceService ProvinceService;

    public ProvincesController(IProvinceService provinceService)
    {
        ProvinceService = provinceService;
    }
    [HttpGet]
    public IActionResult Get([FromQuery] int countryId)
    {
        var result = ProvinceService.GetList(countryId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
