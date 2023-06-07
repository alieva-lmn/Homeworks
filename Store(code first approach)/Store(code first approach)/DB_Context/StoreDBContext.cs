using Microsoft.EntityFrameworkCore;
using Store_code_first_approach_.Models;
using Microsoft.Extensions.Configuration;


namespace Store_code_first_approach_.DB_Context
{
    public class StoreDBContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("LocalConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
