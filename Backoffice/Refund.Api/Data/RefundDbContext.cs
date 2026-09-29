using Microsoft.EntityFrameworkCore;
using Refund.Api.Models.Refund;

namespace Refund.Api.Data
{
    public class RefundDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<RefundModel> Refunds { get; set; }

        public RefundDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
        }
    }
}
