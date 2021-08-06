using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using game_api.InputModel;
using game_api.ViewModel;
namespace game_api.Services
{
    public interface IGameService : IDisposable
    {
        Task<List<GameViewModel>> Get(int page, int quantity);
        Task<GameViewModel> Get(Guid id);
        Task<GameViewModel> Create(GameInputModel game);
        Task Refresh(Guid id, double price);
        Task Remove(Guid id);
    }
}