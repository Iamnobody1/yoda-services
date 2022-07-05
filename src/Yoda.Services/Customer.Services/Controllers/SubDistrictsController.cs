using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Services.District;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class SubDistrictsController : ControllerBase
{
    private readonly ISubDistrictService _subDistrictService;

    public SubDistrictsController(ISubDistrictService subDistrictService)
    {
        _subDistrictService = subDistrictService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int provinceId)
    {
        var result = _subDistrictService.GetList(provinceId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
