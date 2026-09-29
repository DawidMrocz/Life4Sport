using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.Api.Data
{
    public class BasketConfiguration : IEntityTypeConfiguration<BasketModel>
    {
        public void Configure(EntityTypeBuilder<BasketModel> modelBuilder)
        {
            modelBuilder
                .Property(p => p.BasketId)
                .HasColumnName("Id")
            .UseIdentityColumn();
        }
    }
}
