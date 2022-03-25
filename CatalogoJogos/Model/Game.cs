using System;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CatalogoJogos.Model
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Price { get; set; }

        internal AppDb Db { get; set; }

        public Game()
        {

        }
        public Game(AppDb db)
        {
            Db = db;
        }
        public async Task InsertAsync(Game game)
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            var Id = game.Id;
            var Name = game.Name;
            var Producer = game.Producer;
            var Price = game.Price;
            cmd.CommandText = @"INSERT INTO Jogos (Id,Name,Producer,Price) VALUES (@Id, @Name, @Producer, @Price);";
            BindParams(cmd);
            await cmd.Transaction.CommitAsync();
            await txn.CommitAsync();
        }

        public async Task UpdateAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Jogos SET Name=@Name,Producer=@Producer,Price=@Price WHERE Id=@Id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.Transaction.CommitAsync();
            await txn.CommitAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM Jogos WHERE Id=@Id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Id",
                DbType = DbType.Guid,
                Value = Id,
            });
        }
        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Id",
                DbType = DbType.Guid,
                Value = Id,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Name",
                DbType = DbType.String,
                Value = Name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Producer",
                DbType = DbType.String,
                Value = Producer,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Price",
                DbType = DbType.Double,
                Value = Price,
            });
        }
    }
}
