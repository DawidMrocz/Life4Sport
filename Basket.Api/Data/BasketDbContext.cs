using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.Api.Data
{
    public class BasketDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Models.BasketModel> Baskets { get; set; }
        public DbSet<BasketItemModel> BasketItems { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<DiscountModel> Discounts { get; set; }
        public DbSet<BasketUserModel> BasketUser { get; set; }

        public BasketDbContext(IConfiguration configuration)
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
