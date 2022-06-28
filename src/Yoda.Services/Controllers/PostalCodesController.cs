using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Services.PostalCode;

namespace Yoda.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostalCodesController : ControllerBase
    {
        private readonly IPostalCodeService _postalService;

        public PostalCodesController(IPostalCodeService postalService)
        {
            _postalService = postalService;
        }
        [HttpGet]
        public IActionResult GetList([FromQuery] int id)
        {
            var result = _postalService.GetList(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
