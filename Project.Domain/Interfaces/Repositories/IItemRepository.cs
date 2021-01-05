using Project.Domain.Models;
using System;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IDisposable
    {
        void Add(Item item);
        void Update(Item item);
        void Remove(Item item);
        List<Item> GetAll();
        List<Item> GetDone();
        List<Item> GetPending();
        Item GetById(int id);

    }
}
