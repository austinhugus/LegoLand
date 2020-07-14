using System;
using System.Collections.Generic;
using Legoland.Models;
using Legoland.Repositories;

namespace Legoland.Services
{
    public class BricksService
    {
        private readonly BricksRepository _repo;
        public BricksService(BricksRepository repo)
        {
            _repo = repo;
        }


        internal IEnumerable<Brick> Get()
        {
            return _repo.Get();
        }
        internal Brick Get(int Id)
        {
            Brick exists = _repo.GetById(Id);
            if (exists == null) { throw new Exception("Invalid Brick Dawg!"); }
            return exists;
        }

        internal object Create(Brick newBrick)
        {
            int id = _repo.Create(newBrick);
            newBrick.Id = id;
            return newBrick;
        }
        public Brick Edit(Brick editBrick)
        {
            Brick original = Get(editBrick.Id);
            original.Name = editBrick.Name.Length > 0 ? editBrick.Name : original.Name;
            original.Color = editBrick.Color != null ? editBrick.Color : original.Color;
            original.Description = editBrick.Description.Length > 0 ? editBrick.Description : original.Description;
            return _repo.Edit(original);
        }

        public Brick Delete(int id)
        {
            Brick exists = Get(id);
            _repo.Delete(id);
            return exists;
        }
    }


}
