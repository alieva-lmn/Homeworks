using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.DB_Context
{
    public class Database_Context : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

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
            var company = modelBuilder.Entity<Company>();
            var employee = modelBuilder.Entity<Employee>();

            company.HasKey(c => c.Id);
            company.Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Company>().HasIndex(c => c.Name).IsUnique();

            employee.HasKey(e => e.Id);
            employee.Property(e => e.Name).IsRequired();
            employee.HasOne(e => e.Company).WithOne().HasForeignKey<Employee>(e => e.CompanyId);
        }
    }
}
