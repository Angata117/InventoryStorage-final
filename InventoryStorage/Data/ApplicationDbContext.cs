using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryStorage.Models;
using Microsoft.EntityFrameworkCore;
namespace InventoryStorage.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemHistory> Histories { get; set; }
    }
}
