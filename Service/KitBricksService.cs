using System;
using System.Collections.Generic;
using Legoland.Models;
using Legoland.Repositories;

namespace Legoland.Services
{
    public class KitBricksService
    {
        private readonly KitBricksRepository _repo;
        public KitBricksService(KitBricksRepository repo)
        {
            _repo = repo;
        }

        public DTOKitBrick Get(int Id)
        {
            DTOKitBrick exists = _repo.GetById(Id);
            if (exists == null) { throw new Exception("Invalid KitBrick"); }
            return exists;
        }
        public DTOKitBrick Create(DTOKitBrick newKitBrick)
        {
            int id = _repo.Create(newKitBrick);
            newKitBrick.Id = id;
            return newKitBrick;
        }

        public DTOKitBrick Delete(int id)
        {
            DTOKitBrick exists = Get(id);
            _repo.Delete(id);
            return exists;
        }

        public IEnumerable<KitBrick> GetIngsByTacoId(int id)
        {
            return _repo.GetBricksByKitId(id);
        }
    }
}