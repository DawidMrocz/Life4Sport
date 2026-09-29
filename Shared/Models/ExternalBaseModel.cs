using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Shared.Models
{
    public abstract class ExternalBaseModel<T> : BaseModel
    {
        public T ExternalId { get; set; } = default!;
    }
    public class ExternalBaseModelConfiguration<T> : IEntityTypeConfiguration<ExternalBaseModel<T>> where T : notnull
    {
        public void Configure(EntityTypeBuilder<ExternalBaseModel<T>> modelBuilder)
        {
            modelBuilder.Property(e => e.ExternalId).IsRequired();
        }
    }
}
