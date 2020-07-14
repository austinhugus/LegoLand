using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Legoland.Models;

namespace Legoland.Repositories
{
    public class KitBricksRepository
    {
        private readonly IDbConnection _db;
        public KitBricksRepository(IDbConnection db)
        {
            _db = db;
        }


        internal DTOKitBrick GetById(int Id)
        {
            string sql = "SELECT * FROM kirbricks WHERE id = @Id";
            return _db.QueryFirstOrDefault<DTOKitBrick>(sql, new { Id });
        }

        internal int Create(DTOKitBrick newDTOKitBrick)
        {
            string sql = @"
        INSERT INTO kitbricks
        (kitId, brickId)
        VALUES
        (@KitId, @BrickId);
        SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newDTOKitBrick);
        }

        internal IEnumerable<KitBrick> GetAll()
        {
            string sql = "SELECT * FROM kitbricks";
            return _db.Query<KitBrick>(sql);
        }

        internal void Delete(int Id)
        {
            string sql = "DELETE FROM kitbricks WHERE id = @Id";
            _db.Execute(sql, new { Id });
        }

        internal IEnumerable<KitBrick> GetBricksByKitId(int id)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<KitBrick> GetIngsByKitId(int id)
        {
            string sql = @"
        SELECT
            b.*,
            kb.id as kitBrickId
        FROM kitbricks kb
        INNER JOIN ingredients b ON b.id = kb.brickId
        WHERE(kb.kitId = @id)
        ";
            return _db.Query<KitBrick>(sql, new { id });
        }
    }
}