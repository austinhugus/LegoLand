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
            string sql = "SELECT * FROM kits WHERE id = @kitId";
            return _db.QueryFirstOrDefault<Kit>(sql, new { kitId });
        }

        internal Kit GetById(int kitId)
        {
            throw new NotImplementedException();
        }

        internal int Create(Kit newKit)
        {
            throw new NotImplementedException();
        }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }

        internal Kit Edit(Kit original)
        {
            throw new NotImplementedException();
        }
    }
}