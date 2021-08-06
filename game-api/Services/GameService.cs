using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using game_api.InputModel;
using game_api.ViewModel;
using game_api.Repositories;
using game_api.Exeptions;
using game_api.Entities;



namespace game_api.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<List<GameViewModel>> Get(int page, int quantity)
        {
            var games = await _gameRepository.Get(page, quantity);

            return games.Select(game => new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Studio = game.Studio,
                Price = game.Price,
            }).ToList();
        }

        public async Task<GameViewModel> Get(int id)
        {
            var game = await _gameRepository.Get(id);

            if (game == null)
                return null;

            return new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Studio = game.Studio,
                Price = game.Price,
            };
        }
        public async Task<GameViewModel> Insert(GameInputModel game)
        {
            var gameEntity = await _gameRepository.Insert(game.Name, game.Studio);

            if (gameEntity > 0)
                throw new GameAlreadyExistsException();

            var gameInsert = new Game
            {
                Id = Guid.NewGuid(),
                Name = game.Name,
                Studio = game.Studio,
                Price = game.Price,
            };

            await _gameRepository.Insert(gameInsert);

            return new GameViewModel
            {
                Id = gameInsert.Id,
                Name = gameInsert.Name,
                Studio = gameInsert.Studio,
                Price = gameInsert.Price,
            };
        }
        public async Task Refresh(Guid id, double price)
        {
            var gameEntity = await _gameRepository.Get(id);

            if (gameEntity == null)
                throw new GameNotFoundException();
            gameEntity.Price = price;

            await _gameRepository.Refresh(gameEntity);
        }

        public async Task<bool> Remove(Guid id)
        {
            var game = await _gameRepository.Get(id);

            if (game == null)
                throw new GameNotFoundException();

            await _gameRepository.Delete(id);
        }

        public void Dispose()
        {
            _gameRepository.Dispose();
        }
    }
}