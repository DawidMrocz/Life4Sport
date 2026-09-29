using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.Api.Data
{
    public class ProducerConfiguration : IEntityTypeConfiguration<ProducerModel>
    {
        public void Configure(EntityTypeBuilder<ProducerModel> modelBuilder)
        {
            modelBuilder
                .Property(p => p.ProducerId)
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