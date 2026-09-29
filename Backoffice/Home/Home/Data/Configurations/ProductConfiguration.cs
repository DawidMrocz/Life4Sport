using Home.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Data.Configurations
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
                .Property(p => p.Description)
                .HasMaxLength(200)
                .HasColumnType("nvarchar(max)");


            modelBuilder
                .Property(p => p.Price)
            .IsRequired();



            modelBuilder
                .Property(p => p.Season)
                .HasConversion<string>()
                .IsRequired();

            modelBuilder
                .Property(p => p.Season)
                .HasConversion<string>()
                .IsRequired();

            //modelBuilder
            //    .Property(p => p.Created).HasDefaultValueSql("GETDATE()");

            //modelBuilder
            //    .Property(p => p.Updated).HasDefaultValueSql("GETDATE()");
        }
    }
}
