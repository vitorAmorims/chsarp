using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogos.InputModel;
using CatalogoJogos.ViewModel;

namespace CatalogoJogos.Services
{
    public interface IJogoService
    {
        Task<List<GameViewModel>> GetGames(int page, int amount);
        Task<GameViewModel> GetGame(Guid id);
        Task<GameViewModel> InsertGame(GameInputModel game);
        Task UpdateGame(Guid id, GameInputModel game);
        Task UpdatePriceGame(Guid id, double Price);
        Task Remove(Guid id);
    }
}
