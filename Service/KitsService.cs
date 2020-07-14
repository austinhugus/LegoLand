using System;
using System.Collections.Generic;
using Legoland.Models;
using Legoland.Repositories;

namespace Legoland.Services
{
    public class KitsService
    {
        private readonly KitsRepository _repo;
        public KitsService(KitsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Kit> Get()
        {
            return _repo.Get();
        }
        public Kit Get(int kitId)
        {
            Kit exists = _repo.GetById(kitId);
            if (exists == null) { throw new Exception("Invalid kit mi amigo"); }
            return exists;
        }

        public Kit Create(Kit newKit)
        {
            int id = _repo.Create(newKit);
            newKit.Id = id;
            return newKit;
        }

        public Kit Delete(int id)
        {
            Kit exists = Get(id);
            _repo.Delete(id);
            return exists;
        }

        public Kit Edit(Kit editKit)
        {
            Kit original = Get(editKit.Id);
            original.Name = editKit.Name.Length > 0 ? editKit.Name : original.Name;
            original.Price = editKit.Price > 0 ? editKit.Price : original.Price;
            original.Description = editKit.Description.Length > 0 ? editKit.Description : original.Description;
            return _repo.Edit(original);
        }

    }
}