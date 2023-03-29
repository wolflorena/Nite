using Microsoft.EntityFrameworkCore;
using Nite.API.Repository.Entities;

namespace Nite.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TVShow> TVShows { get; set; }

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


            modelBuilder.Entity<TVShow>()
                .HasData(
                new TVShow()
                {
                    Id = 1,
                    Name = "Game of Thrones",
                    Year = 2011,
                    Audience = "18+",
                    Seasons = 8,
                    Genre = "Drama",
                    Status = "Ended",
                    Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia."
                },
                 new TVShow()
                 {
                     Id = 2,
                     Name = "American Horror Story",
                     Year = 2011,
                     Audience = "18+",
                     Seasons = 10,
                     Genre = "Horror",
                     Status = "On going",
                     Description = "Each season has its own self-contained storyline and characters and it has been posed that each season will introduce a new location as well as new characters and storylines."
                 },
                 new TVShow()
                 {
                     Id = 3,
                     Name = "Dexter",
                     Year = 2006,
                     Audience = "18+",
                     Seasons = 8,
                     Genre = "Mystery",
                     Status = "Ended",
                     Description = "Dexter is a serial killer with a \"code\" which directs his compulsions to kill only the guilty. As a blood spatter analyst for the Miami police, he has access to crime scenes, picking up clues and checking DNA to confirm a target's guilt before he kills them."
                 },
                 new TVShow()
                 {
                     Id = 4,
                     Name = "You",
                     Year = 2018,
                     Audience = "16+",
                     Seasons = 4,
                     Genre = "Psychological thriller",
                     Status = "On going",
                     Description = "The series follows a dangerously charming, intensely obsessive young man who goes to extreme measures to insert himself into the lives of those he is transfixed by."
                 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
