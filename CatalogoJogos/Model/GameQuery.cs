using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CatalogoJogos.Model
{
    public class GameQuery
    {
        public AppDb Db { get; }
        public GameQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Game> FindOneAsync(string id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Name`, `Producer`, `Price` FROM `Jogos` WHERE `Id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.String,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<Game> FindOneAsyncNameProducer(string name, string producer)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@producer",
                DbType = DbType.String,
                Value = producer,
            });
            cmd.CommandText = @"SELECT * FROM Jogos WHERE Name=@name AND Producer=@producer;";
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            if (result.Count() == 0)
            {
                return null;
            }
            return result[0];
        }

        public async Task<List<Game>> FindAllAsync(int page, int amount)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"Select * FROM Jogos;";
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            if (result.Count() == 0)
            {
                return null;
            }
            return result;
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `Jogos`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }


        private async Task<List<Game>> ReadAllAsync(DbDataReader reader)
        {
            var games = new List<Game>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var game = new Game(Db)
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        Producer = reader.GetString(2),
                        Price = reader.GetDouble(3),
                    };
                    games.Add(game);
                }
            }
            return games;
        }
    }
}
