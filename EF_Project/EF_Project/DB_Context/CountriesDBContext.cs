using EF_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.DB_Context
{
    public class CountriesDBContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<GovernmentForms> GovernmentForms { get; set; }

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
            var country = modelBuilder.Entity<Country>();
            var government = modelBuilder.Entity<GovernmentForms>();

            country.HasKey(c => c.ID);
            country.Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            country.Property(c => c.Year).IsRequired();
            country.Property(c => c.Url).IsRequired();
            country.Property(c => c.Population).IsRequired();
            country.Property(c => c.Area).IsRequired();
            country.Property(c => c.GDP).IsRequired();
            country.Property(c => c.HeadOfState).IsRequired();
            country.Property(c => c.Anthem).IsRequired();

            country.HasOne(c => c.GovernmentForms).WithOne().HasForeignKey<Country>(e => e.GovernmentFormID);

            government.HasKey(g => g.ID);
            government.Property(g => g.Form).IsRequired();
        }
    }
}
