using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Catalog.Api.Models;

namespace Catalog.Api.Data
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

            modelBuilder
                .Property(p => p.Created).HasDefaultValueSql("GETDATE()");

            modelBuilder
                .Property(p => p.Updated).HasDefaultValueSql("GETDATE()");
        }
    }
}
