using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Services.SubDistrict;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class SubDistrictsController : ControllerBase
{
    private readonly ISubDistrictService SubDistrictService;

    public SubDistrictsController(ISubDistrictService subDistrictService)
    {
        SubDistrictService = subDistrictService;
    }
    [HttpGet]
    public IActionResult Get([FromQuery] int districtId)
    {
        var result = SubDistrictService.GetList(districtId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
