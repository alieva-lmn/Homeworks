using LastEFHW.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LastEFHW.DB_Context
{
    public class CompaniesDBContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string? connectionString = configuration.GetConnectionString("LocalConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var company = modelBuilder.Entity<Company>();
            var employee = modelBuilder.Entity<Employee>();

            company.HasKey(c => c.ID);
            company.Property(c => c.Name).IsRequired();

            employee.HasKey(e => e.ID);
            employee.Property(e => e.Name).IsRequired();
            employee.Property(e => e.Surname).IsRequired();

            employee.HasOne(e => e.Company).WithOne().HasForeignKey<Employee>(e => e.CompanyID);
        }
    }
}
