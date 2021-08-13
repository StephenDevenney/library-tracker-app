using Library.Tracker.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tracker.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options): base(options)
        { }

        public DbSet<NavMenuEntity> NavMenu { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserRoleEntity> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NavMenuEntity>(DBNavMenu);
            modelBuilder.Entity<UserEntity>(DBUser);
            modelBuilder.Entity<UserRoleEntity>(DBUserRole);
            base.OnModelCreating(modelBuilder);
        }

        private void DBNavMenu(EntityTypeBuilder<NavMenuEntity> _)
        {
            _.ToTable("NavMenu", "security");
            _.HasKey(x => x.NavMenuId);
            _.Property<int>(x => x.NavMenuId).HasColumnName("NavMenuId");
            _.Property<string>(x => x.NavMenuName).HasColumnName("NavMenuName");
            _.Property<string>(x => x.NavMenuTitle).HasColumnName("NavMenuTitle");
            _.Property<string>(x => x.NavMenuRoute).HasColumnName("NavMenuRoute");
        }

        private void DBUser(EntityTypeBuilder<UserEntity> _)
        {
            _.ToTable("User", "security");
            _.HasKey(x => x.UserId);
            _.Property<int>(x => x.UserId).HasColumnName("UserId");
            _.Property<int>(x => x.UserRoleId).HasColumnName("FK_UserRoleId");
            _.Property<string>(x => x.UserName).HasColumnName("UserName");
        }

        private void DBUserRole(EntityTypeBuilder<UserRoleEntity> _)
        {
            _.ToTable("UserRole", "enum");
            _.HasKey(x => x.UserRoleId);
            _.Property<int>(x => x.UserRoleId).HasColumnName("UserRoleId");
            _.Property<string>(x => x.RoleName).HasColumnName("RoleName");
        }
    }
}
