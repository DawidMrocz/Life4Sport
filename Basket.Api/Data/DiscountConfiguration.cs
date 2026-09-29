using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.Api.Data
{
    public class DiscountConfiguration : IEntityTypeConfiguration<DiscountModel>
    {
        public void Configure(EntityTypeBuilder<DiscountModel> modelBuilder)
        {
            modelBuilder
                .Property(p => p.DiscountId)
                .HasColumnName("Id")
            .UseIdentityColumn();

            modelBuilder
                .Property(p => p.DiscountId)
            .IsRequired();

            modelBuilder
                .Property(p => p.Percentage)
            .IsRequired();

            modelBuilder
                .Property(p => p.ValidTo)
                .IsRequired();
        }
    }
}