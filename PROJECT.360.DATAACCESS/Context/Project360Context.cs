using PROJECT._360.DATAACCESS.Migrations;
using PROJECT._360.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.DATAACCESS.Context
{
    public class Project360Context : DbContext
    {
        public Project360Context() : base("name=Project360Context")
        {
            this.Database.CommandTimeout = 180;
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<Project360Context, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithRequired(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
                .WithRequired(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);
            modelBuilder.Entity<UserRole>()
                .HasRequired(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasRequired(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
