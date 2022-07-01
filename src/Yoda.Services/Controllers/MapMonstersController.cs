using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Entities;
using Yoda.Services.Models;
using Yoda.Services.Services.MapMonster;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class MapMonstersController : ControllerBase
{
    private readonly IMapMonsterService _mapMonsterService;

    public MapMonstersController(IMapMonsterService mapMonsterService)
    {
        _mapMonsterService = mapMonsterService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] MapMonsterModel mapMonster)
    {
        var result = _mapMonsterService.Create(mapMonster);
        return Ok(result);
    }

    [HttpPut("{mapMonsterId}")]
    public IActionResult Put([FromRoute] int mapMonsterId, [FromBody] MapMonsterEntity mapMonster)
    {
        _mapMonsterService.Update(mapMonsterId, mapMonster);
        return Ok();
    }

    [HttpDelete("{mapMonsterId}")]
    public IActionResult Delete([FromRoute] int mapMonsterId)
    {
        _mapMonsterService.Delete(mapMonsterId);
        return NoContent();
    }
}
