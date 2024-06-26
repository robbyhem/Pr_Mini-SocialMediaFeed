﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialMediaFeed.DataAccess.Data;

#nullable disable

namespace SocialMediaFeed.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240525202026_Create-Db_Add-ModelTables-To-Db_Insert-Dummy-Data-In-ModelTables")]
    partial class CreateDb_AddModelTablesToDb_InsertDummyDataInModelTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialMediaFeed.Domain.Models.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FolloweeId")
                        .HasColumnType("int");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FolloweeId");

                    b.HasIndex("FollowerId");

                    b.ToTable("Follows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FolloweeId = 1,
                            FollowerId = 2
                        },
                        new
                        {
                            Id = 2,
                            FolloweeId = 1,
                            FollowerId = 3
                        },
                        new
                        {
                            Id = 3,
                            FolloweeId = 1,
                            FollowerId = 4
                        },
                        new
                        {
                            Id = 4,
                            FolloweeId = 2,
                            FollowerId = 4
                        },
                        new
                        {
                            Id = 5,
                            FolloweeId = 6,
                            FollowerId = 5
                        },
                        new
                        {
                            Id = 6,
                            FolloweeId = 3,
                            FollowerId = 6
                        },
                        new
                        {
                            Id = 7,
                            FolloweeId = 4,
                            FollowerId = 6
                        },
                        new
                        {
                            Id = 8,
                            FolloweeId = 5,
                            FollowerId = 6
                        });
                });

            modelBuilder.Entity("SocialMediaFeed.Domain.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 5, 25, 20, 20, 20, 821, DateTimeKind.Utc).AddTicks(5679),
                            Likes = 4,
                            Text = "Hello World",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 25, 20, 20, 20, 821, DateTimeKind.Utc).AddTicks(5684),
                            Likes = 7,
                            Text = "ASP.NET Core is awesome",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 25, 20, 20, 20, 821, DateTimeKind.Utc).AddTicks(5686),
                            Likes = 5,
                            Text = "It's nice to see you again",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SocialMediaFeed.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserName = "Bob"
                        },
                        new
                        {
                            Id = 2,
                            UserName = "Alice"
                        },
                        new
                        {
                            Id = 3,
                            UserName = "Diana"
                        },
                        new
                        {
                            Id = 4,
                            UserName = "Eve"
                        },
                        new
                        {
                            Id = 5,
                            UserName = "Charlie"
                        },
                        new
                        {
                            Id = 6,
                            UserName = "Dave"
                        });
                });

            modelBuilder.Entity("SocialMediaFeed.Domain.Models.Follow", b =>
                {
                    b.HasOne("SocialMediaFeed.Domain.Models.User", "Followee")
                        .WithMany("Followers")
                        .HasForeignKey("FolloweeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialMediaFeed.Domain.Models.User", "Follower")
                        .WithMany("Following")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Followee");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("SocialMediaFeed.Domain.Models.Post", b =>
                {
                    b.HasOne("SocialMediaFeed.Domain.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMediaFeed.Domain.Models.User", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Following");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
