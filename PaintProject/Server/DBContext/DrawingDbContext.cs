using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaintProject.Model;

namespace PaintProject.DBContext
{
    public class DrawingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("LocalConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(p => p.PictureId);
                entity.Property(p => p.ProjectName).HasDefaultValue("Untitled");
                entity.Property(p => p.Date).HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.PicturePath).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(u => u.PicCollection)
                        .WithOne(p => p.User)
                        .HasForeignKey(p => p.UserId);

                entity.Property(u => u.Username).IsRequired();
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.Confirmation).IsRequired();
                entity.Property(u => u.Email).IsRequired();

                entity.HasIndex(u => u.Username).IsUnique();
                entity.HasIndex(u => u.Email).IsUnique();
            });
        }
    }
}
