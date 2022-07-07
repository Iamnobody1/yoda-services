using Microsoft.AspNetCore.Mvc;
using Yoda.Services.MiniGame.Models;
using Yoda.Services.MiniGame.Services.MapMonster;

namespace Yoda.Services.MiniGame.Controllers;

[ApiController]
[Route("map-monsters")]
public class MapMonstersController : ControllerBase
{
    private readonly IMapMonsterService _mapMonsterService;

    public MapMonstersController(IMapMonsterService mapMonsterService)
    {
        _mapMonsterService = mapMonsterService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMonster([FromRoute] int id)
    {
        var result = await _mapMonsterService.GetMonster(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetMonsters([FromQuery] int id)
    {
        var result = await _mapMonsterService.GetMonsters(id);
        if (result == null || !result.Any())
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MapMonsterModel mapMonster)
    {
        var result = await _mapMonsterService.Create(mapMonster);
        return Ok(result);
    }

    [HttpPut("{mapMonsterId}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] MapMonsterModel mapMonster)
    {
        await _mapMonsterService.Update(id, mapMonster);
        return Ok();
    }

    [HttpPut("{mapMonsterId}/decrement-health")]
    public async Task<IActionResult> DecrementHealth([FromRoute] int id, [FromQuery] int value)
    {
        await _mapMonsterService.DecrementHealth(id, value);
        return Ok();
    }

    [HttpDelete("{mapMonsterId}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mapMonsterService.Delete(id);
        return NoContent();
    }
}
