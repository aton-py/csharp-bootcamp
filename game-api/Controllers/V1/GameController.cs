using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using game_api.ViewModel;
using game_api.InputModel;
using game_api.Services;
using game_api.Exeptions;
using Microsoft.AspNetCore.Http;

namespace game_api.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> Get([FromQuery, Range(1, int.MaxValue)] int page = 1, [FromQuery, Range(1, 50)] int quantity = 5)
        {
            var games = await _gameService.Get(page, quantity);

            if (games.Count() == 0)
                return NoContent();

            return Ok(games);
        }


        [HttpGet("{gameId: guid}")]
        public async Task<ActionResult<List<GameViewModel>>> Get([FromRoute] Guid gameId)
        {
            var game = await _gameService.Get(page, quantity);

            if (game.Count() == 0)
                return NoContent();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> InsertGame([FromBody] GameViewModel gameInputModel)
        {
            try
            {
                var game = await _gameService.Insert(gameInputModel);

                return Ok(game);
            }
            catch (GameAlreadyExistsException ex)
            {
                return UnprocessableEntity("There is already a game with this name in this Studio");
            }
        }

        [HttpPut("{gameId: guid}")]
        public async Task<ActionResult> UpdateGame([FromRoute] Guid gameId, [FromBody] GameInputModel gameInputModel)
        {
            try
            {
                await _gameService.Update(gameId, gameInputModel);
                return Ok();
            }
            catch (GameNotFoundException ex)
            {
                return NotFound("This Game does not exist");
            }
        }

        [HttpPatch("{gameId: guid}/{price:double}")]
        public async Task<ActionResult> PatchGame([FromRoute] Guid gameId, [FromRoute] double price)
        {
            try
            {
                await _gameService.Update(gameId, price);
                return Ok();
            }
            catch (GameNotFoundException ex)
            {
                return NotFound("This Game does not exist");
            }
        }

        [HttpDelete("{gameId: guid}")]
        public async Task<AcceptedResult> DeleteGame(Guid gameId)
        {
            try
            {
                await _gameService.Update(gameId);
                return Ok();
            }
            catch (GameNotFoundException ex)
            {
                return NotFound("This Game does not exist");
            }
        }
    }
}