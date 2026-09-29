using Identity.Api.Models;
using Microsoft.EntityFrameworkCore;
using Whislist.Api.Models;

namespace Identity.Api.Data
{
    public class IdentityDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<DiscountModel> Discounts { get; set; }
        public DbSet<ProducerModel> Producers { get; set; }
        public DbSet<WishModel> Wishes { get; set; }

        public IdentityDbContext(IConfiguration configuration)
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
