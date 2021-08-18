using Library.Tracker.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Tracker.Context
{
    public class SqlContext : DbContext
    {
        #region CONSTRUCTOR
        public SqlContext(DbContextOptions<SqlContext> options): base(options)
        { }
        #endregion

        #region DBSET
        public DbSet<NavMenuEntity> NavMenu { get; set; }
        public DbSet<NavMenuRoleEntity> NavMenuRole { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserRoleEntity> UserRole { get; set; }
        public DbSet<AppSettingsEntity> AppSettings { get; set; }
        public DbSet<AppIdleSecsEntity> AppIdleSecs { get; set; }
        public DbSet<ThemeEntity> Theme { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }
        public DbSet<BookEntity> Book { get; set; }
        #endregion

        #region MODELBUILDER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NavMenuEntity>(DBNavMenu);
            modelBuilder.Entity<UserEntity>(DBUser);
            modelBuilder.Entity<UserRoleEntity>(DBUserRole);
            modelBuilder.Entity<AppSettingsEntity>(DBAppSettings);
            modelBuilder.Entity<ThemeEntity>(DBTheme); 
            modelBuilder.Entity<AppIdleSecsEntity>(DBAppIdleSecs);
            modelBuilder.Entity<NavMenuRoleEntity>(DBNavMenuRole);
            modelBuilder.Entity<AuthorEntity>(DBAuthor);
            modelBuilder.Entity<BookEntity>(DBBook);
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region ENUM
        private void DBTheme(EntityTypeBuilder<ThemeEntity> _)
        {
            _.ToTable("Theme", "enum");
            _.HasKey(x => x.ThemeId);
            _.Property<int>(x => x.ThemeId).HasColumnName("ThemeId");
            _.Property<string>(x => x.ThemeName).HasColumnName("ThemeName");
            _.Property<string>(x => x.ClassName).HasColumnName("ClassName");
        }

        private void DBAppIdleSecs(EntityTypeBuilder<AppIdleSecsEntity> _)
        {
            _.ToTable("AppIdleSecs", "enum");
            _.HasKey(x => x.AppIdleSecsId);
            _.Property<int>(x => x.AppIdleSecsId).HasColumnName("AppIdleSecsId");
            _.Property<int>(x => x.IdleTime).HasColumnName("IdleTime");
            _.Property<string>(x => x.Description).HasColumnName("Description");
        }

        private void DBNavMenu(EntityTypeBuilder<NavMenuEntity> _)
        {
            _.ToTable("NavMenu", "enum");
            _.HasKey(x => x.NavMenuId);
            _.Property<int>(x => x.NavMenuId).HasColumnName("NavMenuId");
            _.Property<string>(x => x.NavMenuName).HasColumnName("NavMenuName");
            _.Property<string>(x => x.NavMenuTitle).HasColumnName("NavMenuTitle");
            _.Property<string>(x => x.NavMenuRoute).HasColumnName("NavMenuRoute");
        }

        private void DBUserRole(EntityTypeBuilder<UserRoleEntity> _)
        {
            _.ToTable("UserRole", "enum");
            _.HasKey(x => x.UserRoleId);
            _.Property<int>(x => x.UserRoleId).HasColumnName("UserRoleId");
            _.Property<string>(x => x.RoleName).HasColumnName("RoleName");
        }
        #endregion

        #region SECURITY
        private void DBUser(EntityTypeBuilder<UserEntity> _)
        {
            _.ToTable("User", "security");
            _.HasKey(x => x.UserId);
            _.Property<int>(x => x.UserId).HasColumnName("UserId");
            _.Property<int>(x => x.UserRoleId).HasColumnName("FK_UserRoleId");
            _.Property<string>(x => x.UserName).HasColumnName("UserName");
        }
        private void DBAppSettings(EntityTypeBuilder<AppSettingsEntity> _)
        {
            _.ToTable("AppSettings", "security");
            _.HasKey(x => x.AppSettingsId);
            _.Property<int>(x => x.AppSettingsId).HasColumnName("AppSettingsId");
            _.Property<int>(x => x.UserId).HasColumnName("FK_UserId");
            _.Property<int>(x => x.ThemeId).HasColumnName("FK_ThemeId");
            _.Property<int>(x => x.AppIdleSecsId).HasColumnName("FK_AppIdleSecsId");
            _.Property<bool>(x => x.NavMinimised).HasColumnName("NavMinimised");
        }
        private void DBNavMenuRole(EntityTypeBuilder<NavMenuRoleEntity> _)
        {
            _.ToTable("NavMenuRole", "security");
            _.HasKey(x => x.NavMenuRoleId);
            _.Property<int>(x => x.NavMenuRoleId).HasColumnName("NavMenuRoleId");
            _.Property<int>(x => x.NavMenuId).HasColumnName("FK_NavMenuId");
            _.Property<int>(x => x.UserRoleId).HasColumnName("FK_UserRoleId");
        }
        #endregion

        #region BOOK
        private void DBAuthor(EntityTypeBuilder<AuthorEntity> _)
        {
            _.ToTable("Authors", "book");
            _.HasKey(x => x.AuthorId);
            _.Property<int>(x => x.AuthorId).HasColumnName("AuthorId").ValueGeneratedOnAdd();
            _.Property<string>(x => x.AuthorName).HasColumnName("AuthorName");
        }
        private void DBBook(EntityTypeBuilder<BookEntity> _)
        {
            _.ToTable("BookCollection", "book");
            _.HasKey(x => x.BookId);
            _.Property<int>(x => x.BookId).HasColumnName("BookId");
            _.Property<int>(x => x.UserId).HasColumnName("FK_UserId");
            _.Property<string>(x => x.BookName).HasColumnName("BookName");
            _.Property<string>(x => x.BookSubTitle).HasColumnName("BookSubTitle");
            _.Property<string>(x => x.ISBN).HasColumnName("ISBN");
            _.Property<string>(x => x.Description).HasColumnName("Description");
            _.Property<int>(x => x.PageCount).HasColumnName("PageCount");
            _.Property<string>(x => x.ImageLinkSmall).HasColumnName("ImageLinkSmall");
            _.Property<string>(x => x.ImageLinkStandard).HasColumnName("ImageLinkStandard");
            _.Property<string>(x => x.AuthorIds).HasColumnName("AuthorIds");
        }
        #endregion
    }
}
