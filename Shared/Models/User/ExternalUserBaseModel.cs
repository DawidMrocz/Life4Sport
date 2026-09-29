using Framework.Shared.Enums;
using Framework.Shared.Models.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Framework.Shared.Models.User
{
    [Index(nameof(Email), IsUnique = true)]
    public abstract class ExternalUserBaseModel<T> : UserBaseModel
    {
        public T ExternalId { get; set; } = default!;
    }

    public class ExternalUserBaseModelConfiguration<T> : IEntityTypeConfiguration<ExternalUserBaseModel<T>> where T : notnull
    {
        public void Configure(EntityTypeBuilder<ExternalUserBaseModel<T>> modelBuilder)
        {
            modelBuilder.Property(e => e.ExternalId).IsRequired();
        }
    }
}
