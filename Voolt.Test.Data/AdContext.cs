using Microsoft.EntityFrameworkCore;
using Voolt.Test.Data.Configurations;
using Voolt.Test.Domain;

namespace Voolt.Test.Data
{
    public class AdContext : DbContext
    {
        public AdContext(DbContextOptions<AdContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Ads");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdConfiguration());
        }

        public DbSet<Ad> Ads { get; set; }
    }
}
