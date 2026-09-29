using Catalog.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Data
{
    public class CatalogContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<DiscountModel> Discounts { get; set; }
        public DbSet<ProducerModel> Producers { get; set; }

        public CatalogContext(IConfiguration configuration)
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