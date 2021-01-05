using Project.Data.Context;
using Project.Domain.Models;
using Project.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Project.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        protected readonly SqlContext context;

        public ItemRepository(SqlContext context)
        {
            this.context = context;
        }

        public void Add(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public void Update(Item item)
        {
            context.Items.Update(item);
            context.SaveChanges();
        }

        public void Remove(Item item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }

        public List<Item> GetAll()
        {
            return context.Items.ToList();
        }

        public Item GetById(int id)
        {
            return context.Items.Find(id);
        }

        public List<Item> GetDone()
        {
            return context.Items.Where(i => i.IsDone).ToList();
        }
        public List<Item> GetPending()
        {
            return context.Items.Where(i => !i.IsDone).ToList();            
        }

        public void Dispose()
        {
            context.Dispose();
        }        
    }
}
