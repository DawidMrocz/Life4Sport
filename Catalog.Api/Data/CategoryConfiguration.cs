using Catalog.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Api.Data
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