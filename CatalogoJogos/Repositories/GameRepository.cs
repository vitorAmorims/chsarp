using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoJogos.Model;
using CatalogoJogos.ViewModel;

namespace CatalogoJogos.Repositories
{
    public class GameRepository : IGameRepository
    {
        private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>()
        {
            {Guid.Parse("f6e36dae-fcbb-4282-959b-abec56e80f9c"), new Game{ Id = Guid.Parse("f6e36dae-fcbb-4282-959b-abec56e80f9c"), Name = "God of War", Producer="Sony Interactive", Price=200}},
            {Guid.Parse("3b97fa7f-3a6d-4cc4-9b68-b80f8687ec4a"), new Game{ Id = Guid.Parse("3b97fa7f-3a6d-4cc4-9b68-b80f8687ec4a"), Name = "Shadow of the Colossus", Producer="Sony Computer", Price=180}},
            {Guid.Parse("dfc0c6c3-c206-4f6c-ad51-75bc7bb5a6f4"), new Game{ Id = Guid.Parse("dfc0c6c3-c206-4f6c-ad51-75bc7bb5a6f4"), Name = "Grand Theft Auto", Producer="Rockstar North", Price=300}},
            {Guid.Parse("b96aabce-dc81-4b6f-be76-3098397b699d"), new Game{ Id = Guid.Parse("b96aabce-dc81-4b6f-be76-3098397b699d"), Name = "Devil May Cry", Producer="Capcom", Price=320}},
            {Guid.Parse("ecb134be-f9c1-4d02-92c5-537ec6e8d34e"), new Game{ Id = Guid.Parse("ecb134be-f9c1-4d02-92c5-537ec6e8d34e"), Name = "Resident Evil", Producer="Capcom", Price=400}}
        };

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<GameViewModel> GetGame(Guid id)
        {
            var result = games.Where(game => game.Value.Id == id);
            if (result.Count() == 0)
                return null;
            return Task.FromResult(result as GameViewModel);
        }

        public Task<Game> GetGameNameProducer(string name, string producer)
        {
            var result = games.Select(game =>
            game.Value.Name.Equals(name)
            && game.Value.Producer.Equals(producer));

            if (result.Count() == 0)
                return null;
            return Task.FromResult(result as Game);
        }

        public Task<List<Game>> GetGames(int page, int amount)
        {
            return Task.FromResult(games.Values.Skip((page - 1) * amount).Take(amount).ToList());
        }

        public Task InsertGame(Game game)
        {
            if (games.ContainsKey(game.Id))
            {
                games.Add(game.Id, game);
                return Task.CompletedTask;
            }
            return null;
        }

        public Task Remove(Guid id)
        {
            if (games.ContainsKey(id))
            {
                games.Remove(id);
                return Task.CompletedTask;
            }
            return null;
        }

        public Task UpdateGame(Game game)
        {
            if (games.ContainsKey(game.Id))
            {
                games[game.Id] = game;
                return Task.CompletedTask;
            }
            return null;
        }

        public Task UpdatePriceGame(Guid id, double Price)
        {
            if (games.ContainsKey(id))
            {
                games[id].Price = Price;
                return Task.CompletedTask;
            }
            return null;
        }
    }
}
