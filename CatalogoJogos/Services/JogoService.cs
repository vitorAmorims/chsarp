using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoJogos.Exceptions;
using CatalogoJogos.InputModel;
using CatalogoJogos.Model;
using CatalogoJogos.Repositories;
using CatalogoJogos.ViewModel;

namespace CatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IGameRepository _jogoRepository;
        public JogoService(IGameRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<GameViewModel> GetGame(Guid id)
        {
            var game = await _jogoRepository.GetGame(id);

            if (game == null)
                throw new RegisteredNotGameException();

            return game;
        }

        public async Task<GameViewModel> GetGameNameProducer(string name, string producer)
        {
            var game = await _jogoRepository.GetGameNameProducer(name, producer);
            if (game == null)
                throw new RegisteredNotGameException();

            return new GameViewModel()
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };
        }

        public async Task<List<GameViewModel>> GetGames(int page, int amount)
        {
            var games = await _jogoRepository.GetGames(page, amount);

            return games.Select(game => new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            }).ToList();
        }

        public async Task<GameViewModel> InsertGame(GameInputModel game)
        {
            var entityGame = await _jogoRepository.GetGameNameProducer(game.Name, game.Producer);
            if(entityGame != null)
                throw new RegisteredGameException();
            
            var newGame = new Game(){
                Id = Guid.NewGuid(),
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };
            await _jogoRepository.InsertGame(newGame);
            return new GameViewModel(){
                Id = newGame.Id,
                Name = newGame.Name,
                Producer = newGame.Producer,
                Price = newGame.Price
            };
        }

        public async Task Remove(Guid id)
        {
            var game = _jogoRepository.GetGame(id);

            if (game == null)
                throw new RegisteredNotGameException();

            await _jogoRepository.Remove(id);
        }

        public async Task UpdateGame(Guid id, GameInputModel game)
        {
            var entityGame = await _jogoRepository.GetGame(id);
            if (game == null)
                throw new RegisteredNotGameException();
            
            entityGame.Id = id;
            entityGame.Name = game.Name;
            entityGame.Producer = game.Producer;
            entityGame.Price = game.Price;

            var newGame = new Game(){
                Id = entityGame.Id,
                Name = entityGame.Name,
                Producer = entityGame.Producer,
                Price = entityGame.Price
            };

            await _jogoRepository.UpdateGame(newGame);
        }

        public async Task UpdatePriceGame(Guid id, double Price)
        {
            var entityGame = await _jogoRepository.GetGame(id);
            if (entityGame == null)
                throw new RegisteredNotGameException();
            
            entityGame.Price = Price;
            
            var newGame = new Game(){
                Id = entityGame.Id,
                Name = entityGame.Name,
                Producer = entityGame.Producer,
                Price = entityGame.Price
            };
            await _jogoRepository.UpdateGame(newGame);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
