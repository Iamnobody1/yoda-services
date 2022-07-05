using Microsoft.AspNetCore.Mvc;
using Yoda.Services.MiniGame.Entities;
using Yoda.Services.MiniGame.Models;
using Yoda.Services.MiniGame.Services.Monster;

namespace Yoda.Services.MiniGame.Controllers
{
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
        public IActionResult Get([FromRoute] int id)
        {
            var result = _monsterService.GetMonsterById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MonsterModel monster)
        {
            var result = _monsterService.Create(monster);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MonsterEntity monster)
        {
            _monsterService.Update(id, monster);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _monsterService.Delete(id);
            return NoContent();
        }
    }
}
