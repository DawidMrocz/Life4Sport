using Home.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> modelBuilder)
        {

            modelBuilder.ToTable("Category");
            modelBuilder
                .Property(p => p.CategoryId)
                .HasColumnName("Id")
            .UseIdentityColumn();

            modelBuilder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .HasColumnType("nvarchar(250)")
            .IsRequired();
        }
    }
}