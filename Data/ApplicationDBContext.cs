using FileSystemManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemManagement.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> Options) : base(Options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Post>().HasOne(p => p.User).WithMany(u => u.Posts);

            modelBuilder.Entity<User>().HasOne(u => u.Role).WithMany(r => r.Users);

            modelBuilder.Entity<Message>().HasOne(m => m.Sender).WithMany(u => u.SentMessages);

            modelBuilder.Entity<Message>().HasOne(m => m.Receiver).WithMany(u => u.ReceivedMessages);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
