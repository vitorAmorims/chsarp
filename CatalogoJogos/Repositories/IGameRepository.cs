using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogos.InputModel;
using CatalogoJogos.Model;
using CatalogoJogos.ViewModel;

namespace CatalogoJogos.Repositories
{
    public interface IGameRepository: IDisposable
    {
        Task<List<Game>> GetGames(int page, int amount);
        Task<Game> GetGame(Guid id);
        Task<Game> GetGameNameProducer(string name, string producer);
        Task InsertGame(Game game);
        Task UpdateGame(Game game);
        Task UpdatePriceGame(Guid id, double Price);
        Task Remove(Guid id);
    }
}
