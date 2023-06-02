using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_first_hw;

public partial class StoreContext : DbContext
{
    public StoreContext()
    {
    }

    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-HVUR0JDE; Initial Catalog=Store; Integrated Security=True; Connect Timeout=30; TrustServerCertificate=True; Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC2747993BEA");

            entity.HasIndex(e => e.Name, "UQ__Categori__737584F64F16CC0D").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC2703548AF1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Categories).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoriesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Catego__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
