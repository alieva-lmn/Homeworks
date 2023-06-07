using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_final;

public partial class CountriesDatabaseContext : DbContext
{
    public CountriesDatabaseContext()
    {
    }

    public CountriesDatabaseContext(DbContextOptions<CountriesDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<GovernmentForm> GovernmentForms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-HVUR0JDE; Initial Catalog=CountriesDatabase; Integrated Security=True; Connect Timeout=30; TrustServerCertificate=True; Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC27CBE278DC");

            entity.ToTable("Country");

            entity.HasIndex(e => e.Name, "UQ__Country__737584F6BC2413E4").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Area).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Gdp)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GDP");
            entity.Property(e => e.GovernmentFormId).HasColumnName("GovernmentFormID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Population).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.GovernmentForm).WithMany(p => p.Countries)
                .HasForeignKey(d => d.GovernmentFormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Country__Governm__3C69FB99");
        });

        modelBuilder.Entity<GovernmentForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Governme__3214EC2715B9D83C");

            entity.ToTable("GovernmentForm");

            entity.HasIndex(e => e.Name, "UQ__Governme__737584F6C2064A29").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
