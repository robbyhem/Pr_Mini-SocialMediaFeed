using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaFeed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaFeed.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follow> Follows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, UserName = "Bob" },
               new User { Id = 2, UserName = "Alice"},
               new User { Id = 3, UserName = "Diana" },
               new User { Id = 4, UserName = "Eve" },
               new User { Id = 5, UserName = "Charlie" },
               new User { Id = 6, UserName = "Dave" }
               );

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Text = "Hello World", CreatedAt = DateTime.UtcNow, Likes = 4, UserId = 2},
                new Post { Id = 2, Text = "ASP.NET Core is awesome", CreatedAt = DateTime.UtcNow, Likes = 7, UserId = 1 },
                new Post { Id = 3, Text = "It's nice to see you again", CreatedAt = DateTime.UtcNow, Likes = 5, UserId = 2 }
                );

            modelBuilder.Entity<Follow>().HasData(
              new Follow { Id = 1, FollowerId = 2, FolloweeId = 1 },
              new Follow { Id = 2, FollowerId = 3, FolloweeId = 1 },
              new Follow { Id = 3, FollowerId = 4, FolloweeId = 1 },
              new Follow { Id = 4, FollowerId = 4, FolloweeId = 2 },
              new Follow { Id = 5, FollowerId = 5, FolloweeId = 6 },
              new Follow { Id = 6, FollowerId = 6, FolloweeId = 3 },
              new Follow { Id = 7, FollowerId = 6, FolloweeId = 4 },
              new Follow { Id = 8, FollowerId = 6, FolloweeId = 5 }
              );

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(u => u.Following);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.Followee)
                .WithMany(u => u.Followers);

            //EntityTypeBuilder.Ignore

        }
    }
}
