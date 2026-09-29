using Home.Models.Producer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Data.Configurations
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

            modelBuilder
                .Property(p => p.FileId)
            .IsRequired();
        }
    }
}