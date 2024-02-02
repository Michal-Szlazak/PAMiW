using DataSeeder;
using Microsoft.EntityFrameworkCore;
using ProjectShared.BookStore;
using ProjectShared.User;
using System.Collections.Generic;
using System.Reflection.Emit;
using BookApi.Services.AuthService;
using Microsoft.AspNetCore.Identity;

namespace WeatherApp.API.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            User user = new User();
            user.DateCreated = DateTime.Now;
            user.Username = "Admin";
            user.Email = "admin@admin";
            user.Role = "Admin";
            user.Id = 1234145134;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("adminpro"));
            }
            modelBuilder.Entity<User>().HasData(user);
            base.OnModelCreating(modelBuilder);
        }
    }
}