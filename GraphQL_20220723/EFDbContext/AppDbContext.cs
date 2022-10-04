using GraphQL_20220723.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GraphQL_20220723.EFDbContext
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetConnectionString("AppDb");
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        public DbSet<Region> Region { get; set; }
    }
}
