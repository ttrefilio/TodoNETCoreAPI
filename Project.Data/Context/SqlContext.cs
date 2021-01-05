using Microsoft.EntityFrameworkCore;
using Project.Domain.Models;

namespace Project.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) :  base(options) { }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ItemMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
