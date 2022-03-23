using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogos.InputModel;
using CatalogoJogos.Repositories;
using CatalogoJogos.ViewModel;

namespace CatalogoJogos.Services
{
    public class JogoService: IJogoService
    {
        private readonly IGameRepository _jogoRepository;
        public JogoService(IGameRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public Task<GameViewModel> GetGame(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GameViewModel> GetGameNameProducer(string name, string producer)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameViewModel>> GetGames(int page, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<GameViewModel> InsertGame(GameInputModel game)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGame(Guid id, GameInputModel game)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePriceGame(Guid id, double Price)
        {
            throw new NotImplementedException();
        }
    }
}
