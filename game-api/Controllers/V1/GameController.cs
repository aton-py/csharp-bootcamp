using Microsoft.AspNetCore.Mvc;

namespace game_api.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> Get()
        {
            return Ok();
        }

        [HttpGet("{gameId: guid}")]
        public async Task<ActionResult<List<object>>> Get(Guid gameId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<object>> InsertGame(object game)
        {
            return Ok();
        }

        [HttpPut("{gameId: guid}")]
        public async Task<ActionResult> UpdateGame(Guid gameId, object game)
        {
            return Ok();
        }

        [HttpPatch("{gameId: guid}/{price:double}")]
        public async Task<ActionResult> PatchGame(Guid gameId, double price)
        {
            return Ok();
        }
        
        [HttpDelete("{gameId: guid}")]
        public async Task<AcceptedResult> DeleteGame(Guid gameId)
        {
            return Ok();
        }
    }
}