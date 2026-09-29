using Comment.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Comment.Api.Data
{
    public class CommentDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        public CommentDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("comment");
            modelBuilder.UseIdentityColumns();
        }
    }
}
