using TODOLIST.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TODOLIST.DBContext
{
    public class ToDoContext : DbContext 
    { 
        public DbSet<User>? Users { get; set; }
        public DbSet<ToDoItem>? ToDo { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Email = "francoexequiel.garcia150@gmail.com",
                    UserId = 1,
                    UserName = "franco",
                    Address = "Membrives 8911",
                    State = true
                });

            modelBuilder.Entity<ToDoItem>().HasData(
               new ToDoItem
               {
                   ToDoId = 1,
                   Title = "Controlers",
                   Description= "Es la descripcion",
                   State = true
               },
               new ToDoItem
               {
                   ToDoId = 2,
                   Title = "Controlers2",
                   Description = "Es la descripcion",
                   State = true
               },
               new ToDoItem
               {
                   ToDoId = 3,
                   Title = "Controlers3",
                   Description = "Es la descripcion",
                   State = true
               });

        }
    }
}

