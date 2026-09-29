using Catalog.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Api.Data
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
    {
        public void Configure(EntityTypeBuilder<CommentModel> modelBuilder)
        {
            modelBuilder
                .Property(p => p.CommentId)
                .HasColumnName("Id")
            .UseIdentityColumn();

            modelBuilder
                .Property(p => p.Rating)
            .IsRequired();

            modelBuilder
                .Property(p => p.UserId)
                .HasMaxLength(10)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
        }
    }
}