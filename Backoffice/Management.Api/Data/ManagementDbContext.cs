using Management.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Api.Data
{
    public class ManagementDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<ManagementModel> Managements { get; set; }
        //public DbSet<OrderModel> Orders { get; set; }
        //public DbSet<OrderItemModel> OrderItems { get; set; }

        public ManagementDbContext(IConfiguration configuration)
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
