using Microsoft.AspNetCore.Mvc;
using Yoda.Services.MiniGame.Models;
using Yoda.Services.MiniGame.Services.Monster;

namespace Yoda.Services.MiniGame.Controllers;

[ApiController]
[Route("[controller]")]
public class MonstersController : ControllerBase
{
    private readonly IMonsterService _monsterService;

    public MonstersController(IMonsterService monsterService)
    {
        _monsterService = monsterService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _monsterService.GetMonsterById(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MonsterModel monster)
    {
        var result = await _monsterService.Create(monster);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] MonsterModel monster)
    {
        await _monsterService.Update(id, monster);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _monsterService.Delete(id);
        return NoContent();
    }
}
