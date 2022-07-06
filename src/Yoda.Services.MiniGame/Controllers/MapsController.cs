using Microsoft.AspNetCore.Mvc;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;
using Yoda.Services.MiniGame.Services.Map;

namespace Yoda.Services.MiniGame.Controllers;

[ApiController]
[Route("[controller]")]
public class MapsController : ControllerBase
{
    private readonly IMapService _mapService;

    public MapsController(IMapService mapService)
    {
        _mapService = mapService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int mapId)
    {
        var result = _mapService.GetMapById(mapId);
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

    [HttpPut("{mapId}")]
    public IActionResult Put([FromRoute] int mapId, [FromBody] MapModel mapMonster)
    {
        _mapService.Update(mapId, mapMonster);
        return Ok();
    }


    [HttpDelete("{mapId}")]
    public IActionResult Delete([FromRoute] int mapId)
    {
        _mapService.Delete(mapId);
        return NoContent();
    }
}
