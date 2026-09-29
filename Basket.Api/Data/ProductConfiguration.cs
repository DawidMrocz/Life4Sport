using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Basket.Api.Models;

namespace Basket.Api.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> modelBuilder)
        {
            modelBuilder
                .Property(p => p.ProductId)
                .HasColumnName("Id")
            .UseIdentityColumn();

            modelBuilder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .HasColumnType("nvarchar(250)")
            .IsRequired();

            modelBuilder
                .Property(p => p.Price)
            .IsRequired();


        }
    }
}