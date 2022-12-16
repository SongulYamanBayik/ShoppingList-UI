using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_DAL.Concrete
{
    public class Context: IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=Db_ShoppingList; integrated security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Navigation(p => p.Category).AutoInclude();
            modelBuilder.Entity<ProductToDoList>().Navigation(x => x.product).AutoInclude();
            modelBuilder.Entity<ProductToDoList>().Navigation(x => x.toDoList).AutoInclude();
            modelBuilder.Entity<ToDoList>().Navigation(x => x.ProductToDoLists).AutoInclude();


        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ProductToDoList> ProductToDoLists { get; set; }
    }
}
