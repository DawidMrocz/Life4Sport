using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.Api.Data
{
    public class BasketItemConfigurationpublic : IEntityTypeConfiguration<BasketItemModel>
    {
        public void Configure(EntityTypeBuilder<BasketItemModel> modelBuilder)
        {
            modelBuilder
                .Property(p => p.ProductId)
                .HasColumnName("Id")
            .UseIdentityColumn();



            modelBuilder
                .Property(p => p.Price)
            .IsRequired();


        }
    }

}
