using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExtendedCore2._1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "SmAspNetUser", schema: "security");
                entity.Property(e => e.Id).HasColumnType("varchar(256)");
                entity.Property(e => e.ConcurrencyStamp).HasColumnType("varchar(256)");
                entity.Property(e => e.PhoneNumber).HasColumnType("varchar(256)");
                entity.Property(e => e.SecurityStamp).HasColumnType("varchar(256)");
            });

            builder.Entity<IdentityRole<string>>(entity =>
            {
                entity.ToTable(name: "SmAspNetRole", schema: "security");
                entity.Property(e => e.Id).HasColumnType("varchar(256)");
                entity.Property(e => e.ConcurrencyStamp).HasColumnType("varchar(256)");
                entity.Property(e => e.Name).HasColumnType("varchar(256)");
                entity.Property(e => e.NormalizedName).HasColumnType("varchar(256)");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("SmAspNetUserClaim", "security");
                entity.Property(e => e.ClaimType).HasColumnType("varchar(256)");
                entity.Property(e => e.ClaimValue).HasColumnType("varchar(256)");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("SmAspNetUserLogin", "security");
                entity.Property(e => e.ProviderDisplayName).HasColumnType("varchar(256)");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("SmAspNetRoleClaim", "security");
                entity.Property(e => e.ClaimType).HasColumnType("varchar(256)");
                entity.Property(e => e.ClaimValue).HasColumnType("varchar(256)");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("SmAspNetUserRole", "security");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("SmAspNetUserToken", "security");
            });
        }
    }
}
