using Discount.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Discount.Api.Data
{
    public class DiscountDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<DiscountModel> Discounts { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        public DiscountDbContext(IConfiguration configuration)
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
