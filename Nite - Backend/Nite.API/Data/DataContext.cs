using Microsoft.EntityFrameworkCore;
using Nite.API.Repository.Entities;

namespace Nite.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        { 
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    Username = "deeagabor",
                    Email = "deeagabor@gmail.com",
                    Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                    IsAdmin = true
                },
                new User()
                {
                    Id = 2,
                    Username = "wolflorena",
                    Email = "wolflorena@gmail.com",
                    Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                    IsAdmin = true
                },
                new User()
                {
                    Id = 3,
                    Username = "test1",
                    Email = "testunu@gmail.com",
                    Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                    IsAdmin = false
                },
                new User()
                {
                    Id = 4,
                    Username = "test2",
                    Email = "testdoi@gmail.com",
                    Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                    IsAdmin = false
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
