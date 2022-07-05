using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Services.District;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class DistrictsController : ControllerBase
{
    private readonly IDistrictService _districtService;

    public DistrictsController(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int provinceId)
    {
        var result = _districtService.GetList(provinceId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
