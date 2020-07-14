using System.Collections.Generic;
using System.Data;
using System;
using Dapper;
using Legoland.Models;

namespace Legoland.Repositories
{
    public class KitsRepository
    {
        private readonly IDbConnection _db;
        public KitsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Kit> Get()
        {
            string sql = "SELECT * FROM kits";
            return _db.Query<Kit>(sql);
        }

        internal Kit GetById(int kitId)
        {
            string sql = "SELECT * FROM kits WHERE id = @kitId";
            return _db.QueryFirstOrDefault<Kit>(sql, new { kitId });
        }

        internal int Create(Kit newKit)
        {
            string sql = @"
            INSERT INTO kits
            (description, name, price)
            VALUES
            (@Description, @Name, @Price);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newKit);
        }

        internal Kit Edit(Kit original)
        {
            string sql = @"
           UPDATE kits
           SET
            name = @Name,
            description = @Description,
            price = @Price
            WHERE id = @Id;
            SELECT * FROM kits WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Kit>(sql, original);
        }

        internal void Delete(int Id)
        {
            string sql = "DELETE FROM kits WHERE id = @Id";
            _db.Execute(sql, new { Id });
        }
    }
}