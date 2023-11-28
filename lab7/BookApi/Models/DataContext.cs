using DataSeeder;
using Microsoft.EntityFrameworkCore;
using ProjectShared.BookStore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace WeatherApp.API.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Book>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            */
            modelBuilder.Entity<Book>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Book>()
                .Property(p => p.Author)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Book>()
                .Property(p => p.Description)
                .HasMaxLength(2000);

            modelBuilder.Entity<Book>().HasData(BookSeeder.GenerateBookData());
        }
    }
}