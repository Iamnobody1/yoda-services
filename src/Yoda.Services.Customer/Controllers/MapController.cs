using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Models;
using Yoda.Services.Services.Map;

namespace Yoda.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapController : ControllerBase
    {
        private readonly IMapService _mapService;

        public MapController(IMapService mapService)
        {
            _mapService = mapService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _mapService.GetMapId(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("")]
        public IActionResult GetList([FromQuery] int start, [FromQuery] int length)
        {
            var result = _mapService.GetList(start, length);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MapModel map)
        {
            var result = _mapService.Create(map);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MapModel map)
        {
            _mapService.Update(id, map);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _mapService.Delete(id);
            return NoContent();
        }

    }
}
