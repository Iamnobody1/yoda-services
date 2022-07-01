using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Entities;
using Yoda.Services.Models;
using Yoda.Services.Services.Monster;

namespace Yoda.Services.Controllers
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
        [HttpGet]
        public IActionResult Get([FromQuery] int Id)
        {
            var result = _monsterService.GetListMonster(Id);
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
