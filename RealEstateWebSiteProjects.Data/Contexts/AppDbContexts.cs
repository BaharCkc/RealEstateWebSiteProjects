using Microsoft.EntityFrameworkCore;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RealEstateWebSiteProjects.Data
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<AnnouncementCategory> AnnouncementCategory { get; set; }
        public DbSet<AnnouncementType> AnnouncementType { get; set; }
        public DbSet<DocumentFile> DocumentFile { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
