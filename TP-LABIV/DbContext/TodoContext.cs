using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TP_LABIV.Data.Entities;

namespace TP_LABIV
{
    public class TodoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public TodoContext(DbContextOptions<TodoContext> dbContextOptions) : base(dbContextOptions) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=todos.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Email = "francoexequiel.garcia150@gmail.com",
                    UserId= 1,
                    Name = "franco",
                    Address = "Zeballos 1300",
                    State = true
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.TodoItem)
                .WithOne(ti => ti.User)
                .HasForeignKey(ti => ti.ToDoItemId)
                .IsRequired();
        }
    }
}
