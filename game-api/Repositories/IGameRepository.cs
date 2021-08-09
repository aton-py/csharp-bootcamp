using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using game_api.Entities;

namespace game_api.Repositories
{
    public interface IGameRepository : IDisposable
    {
        Task<List<Game>> Get(int page, int quantity);
        Task<Game> Get(int id);
        Task<List<Game>> Get(string name, string studio);
        Task Insert(Game game);
        Task Update(Game game);
        Task Remove(Guid id);
    }
}