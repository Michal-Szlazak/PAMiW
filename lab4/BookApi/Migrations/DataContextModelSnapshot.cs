﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp.API.Models;

#nullable disable

namespace BookApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shared.BookStore.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Dino Breitenberg",
                            Description = "Sports & Health maroon South Dakota Incredible Course CFA Franc BEAC Kina Bulgarian Lev Avon invoice",
                            Title = "Incredible Small"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Maximilian Luettgen",
                            Description = "e-commerce Direct bypassing sensor bandwidth Handmade Steel Car revolutionary Moldovan Leu Grocery channels",
                            Title = "1080p Cotton"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Camryn Gorczany",
                            Description = "Indonesia magenta Administrator Berkshire Bedfordshire Savings Account teal Shoes, Movies & Kids American Samoa Home Loan Account",
                            Title = "Coordinator Small"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Hailey Buckridge",
                            Description = "repurpose payment Universal Visionary Ergonomic Rubber Pizza Savings Account Inverse Gorgeous Wooden Mouse TCP Licensed Rubber Ball",
                            Title = "IB orange"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Sherman Johns",
                            Description = "Incredible Rubber Intranet Specialist reboot UAE Dirham Technician synergize front-end fuchsia",
                            Title = "open-source Grass-roots"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Maci Stracke",
                            Description = "Usability Fantastic Soft Fish teal copy Handcrafted Borders Team-oriented blockchains analyzer mobile",
                            Title = "RSS Netherlands Antilles"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Bennett Aufderhar",
                            Description = "Summit Licensed Senior deposit explicit Frozen 1080p HTTP moderator Generic",
                            Title = "Personal Loan Account overriding"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Andrew Metz",
                            Description = "Tasty Steel Towels Corporate Savings Account Personal Loan Account Function-based index Integration Checking Account copying Assimilated",
                            Title = "Refined Refined Granite Shoes"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Gregoria Okuneva",
                            Description = "Clothing, Home & Books invoice Sri Lanka Rupee Identity deposit Creative Facilitator Sudanese Pound e-tailers redundant",
                            Title = "array Computers, Grocery & Books"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Lori Cormier",
                            Description = "parse Identity Investment Account incentivize value-added Vermont Intranet RAM Industrial synthesizing",
                            Title = "Electronics & Health Representative"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
