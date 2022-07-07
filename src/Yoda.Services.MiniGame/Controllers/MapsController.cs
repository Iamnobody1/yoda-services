using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var result = await _mapService.GetMapById(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MapModel map)
    {
        var result = await _mapService.Create(map);
        return Ok(result);
    }

    [HttpPut("{mapId}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] MapModel mapMonster)
    {
        await _mapService.Update(id, mapMonster);
        return Ok();
    }

    [HttpDelete("{mapId}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mapService.Delete(id);
        return NoContent();
    }
}
