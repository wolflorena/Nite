﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nite.API.Data;

#nullable disable

namespace Nite.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230328164011_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nite.API.Repository.Entities.TVShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Audience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seasons")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TVShows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Audience = "18+",
                            Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                            Genre = "Drama",
                            Name = "Game of Thrones",
                            Seasons = 8,
                            Status = "Ended",
                            Year = 2011
                        },
                        new
                        {
                            Id = 2,
                            Audience = "18+",
                            Description = "Each season has its own self-contained storyline and characters and it has been posed that each season will introduce a new location as well as new characters and storylines.",
                            Genre = "Horror",
                            Name = "American Horror Story",
                            Seasons = 10,
                            Status = "On going",
                            Year = 2011
                        },
                        new
                        {
                            Id = 3,
                            Audience = "18+",
                            Description = "Dexter is a serial killer with a \"code\" which directs his compulsions to kill only the guilty. As a blood spatter analyst for the Miami police, he has access to crime scenes, picking up clues and checking DNA to confirm a target's guilt before he kills them.",
                            Genre = "Mystery",
                            Name = "Dexter",
                            Seasons = 8,
                            Status = "Ended",
                            Year = 2006
                        },
                        new
                        {
                            Id = 4,
                            Audience = "16+",
                            Description = "The series follows a dangerously charming, intensely obsessive young man who goes to extreme measures to insert himself into the lives of those he is transfixed by.",
                            Genre = "Psychological thriller",
                            Name = "You",
                            Seasons = 4,
                            Status = "On going",
                            Year = 2018
                        });
                });

            modelBuilder.Entity("Nite.API.Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "deeagabor@gmail.com",
                            IsAdmin = true,
                            Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                            Username = "deeagabor"
                        },
                        new
                        {
                            Id = 2,
                            Email = "wolflorena@gmail.com",
                            IsAdmin = true,
                            Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                            Username = "wolflorena"
                        },
                        new
                        {
                            Id = 3,
                            Email = "testunu@gmail.com",
                            IsAdmin = false,
                            Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                            Username = "test1"
                        },
                        new
                        {
                            Id = 4,
                            Email = "testdoi@gmail.com",
                            IsAdmin = false,
                            Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                            Username = "test2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}