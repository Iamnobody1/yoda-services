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
    public async Task<IActionResult> Get([FromQuery] int mapId)
    {
        var result = await _mapService.GetMapById(mapId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MapModel map)
    {
        var result = await _mapService.CreateAsync(map);
        return Ok(result);
    }

    [HttpPut("{mapId}")]
    public async Task<IActionResult> Put([FromRoute] int mapId, [FromBody] MapModel mapMonster)
    {
        await _mapService.Update(mapId, mapMonster);
        return Ok();
    }


    [HttpDelete("{mapId}")]
    public async Task<IActionResult> Delete([FromRoute] int mapId)
    {
        await _mapService.Delete(mapId);
        return NoContent();
    }
}
