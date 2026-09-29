using Home.Models.Category;
using Home.Models.Producer;
using Home.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Home.Data
{
    public class ProductDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProducerModel> Producers { get; set; }

        public ProductDbContext(IConfiguration configuration)
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
