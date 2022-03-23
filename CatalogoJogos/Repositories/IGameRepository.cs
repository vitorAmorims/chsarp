using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogos.InputModel;
using CatalogoJogos.ViewModel;

namespace CatalogoJogos.Repositories
{
    public interface IGameRepository
    {
        Task<List<GameViewModel>> GetGames(int page, int amount);
        Task<GameViewModel> GetGame(Guid id);
        Task<GameViewModel> GetGameNameProducer(string name, string producer);
        Task<GameViewModel> InsertGame(GameInputModel game);
        Task UpdateGame(GameInputModel game);
        Task UpdatePriceGame(Guid id, double Price);
        Task Remove(Guid id);
    }
}
