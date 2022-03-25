using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogoJogos.Exceptions;
using CatalogoJogos.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

// https://mysqlconnector.net/tutorials/net-core-mvc/
namespace CatalogoJogos.Repositories
{
    public class GameMySqlRepository : IGameRepository
    {
        public AppDb Db { get; set; }

        public GameMySqlRepository(AppDb db)
        {
            Db = db;
        }

        public void Dispose()
        {
            Db.Connection.Dispose();
        }

        public async Task<Game> GetGame(Guid id)
        {
            await Db.Connection.OpenAsync();
            var query = new GameQuery(Db);
            var result = await query.FindOneAsync(id.ToString());
            return result;
        }

        public async Task<Game> GetGameNameProducer(string name, string producer)
        {
            await Db.Connection.OpenAsync();
            var query = new GameQuery(Db);
            var result = await query.FindOneAsyncNameProducer(name, producer);
            return result;
        }

        public async Task<List<Game>> GetGames(int page, int amount)
        {
            await Db.Connection.OpenAsync();
            var query = new GameQuery(Db);
            var result = await query.FindAllAsync(page, amount);
            if (result == null)
                return null;
            return result;
        }

        public async Task InsertGame(Game game)
        {
            var query = new Game(Db);
            await query.InsertAsync(game);
        }

        public async Task Remove(Guid id)
        {
            await Db.Connection.OpenAsync();
            var query = new GameQuery(Db);
            var result = await query.FindOneAsync(id.ToString());
            if (result is null)
                throw new RegisteredNotGameException();
            await result.DeleteAsync();
        }

        public async Task UpdateGame(Game game)
        {
            // await Db.Connection.OpenAsync();
            // var query = new GameQuery(Db);
            // var result = await query.FindOneAsync(game.Id.ToString());
            // if (result is null)
            //     throw new RegisteredNotGameException();
            await game.UpdateAsync();
            // var query = new Game(Db);
            // await query.UpdateAsync(game);
        }
        public Task UpdatePriceGame(Guid id, double Price)
        {
            throw new NotImplementedException();
        }
    }
}
