using Microsoft.EntityFrameworkCore;
using Raport.Api.Models;

namespace Raport.Api.Data
{
    public class RaportDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<RaportModel> Raports { get; set; }

        public RaportDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("raport");
            modelBuilder.UseIdentityColumns();
        }
    }
}
