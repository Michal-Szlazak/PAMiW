﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp.API.Models;

#nullable disable

namespace BookApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240104092148_AuthMigration")]
    partial class AuthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectShared.BookStore.Book", b =>
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

            modelBuilder.Entity("ProjectShared.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
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
                            Id = 1234145134,
                            DateCreated = new DateTime(2024, 1, 4, 10, 21, 48, 674, DateTimeKind.Local).AddTicks(3069),
                            Email = "admin@admin",
                            PasswordHash = new byte[] { 201, 204, 239, 115, 1, 219, 121, 5, 93, 179, 25, 174, 212, 136, 72, 199, 172, 216, 66, 209, 158, 144, 195, 9, 53, 68, 187, 78, 17, 176, 5, 161, 96, 156, 196, 82, 236, 25, 173, 135, 137, 189, 35, 211, 22, 43, 188, 125, 13, 58, 89, 7, 177, 154, 136, 168, 101, 230, 176, 59, 140, 43, 238, 87 },
                            PasswordSalt = new byte[] { 232, 136, 51, 203, 86, 185, 77, 174, 187, 0, 165, 65, 44, 183, 168, 240, 73, 159, 224, 5, 156, 197, 161, 201, 90, 252, 202, 180, 178, 106, 107, 212, 175, 171, 247, 132, 198, 11, 73, 20, 72, 185, 7, 226, 225, 5, 190, 214, 225, 155, 237, 100, 190, 98, 66, 166, 201, 81, 136, 99, 251, 162, 62, 167, 183, 246, 210, 51, 176, 192, 181, 251, 28, 76, 191, 191, 240, 200, 24, 161, 68, 223, 162, 196, 123, 174, 115, 11, 244, 238, 135, 158, 80, 226, 228, 221, 224, 208, 244, 182, 218, 70, 72, 222, 1, 25, 36, 79, 193, 27, 241, 109, 197, 100, 104, 118, 214, 153, 61, 74, 93, 221, 220, 179, 200, 168, 185, 163 },
                            Role = "Admin",
                            Username = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
