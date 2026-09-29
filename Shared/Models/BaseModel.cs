using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; } = default!;
        public DateTime Created { get; set; }
        public int CreatedById { get; set; } = 1;
        public DateTime? Updated { get; set; }
        public int? UpdatedById { get; set; }
    }

    //public abstract class BaseModelConfiguration<TBase> : IEntityTypeConfiguration<TBase>
    //where TBase : BaseModel<int>
    //{
    //    public virtual void Configure(EntityTypeBuilder<TBase> modelBuilder)
    //    {
    //        modelBuilder.Property(e => e.Created)
    //           .HasDefaultValueSql("(getdate())");

    //        modelBuilder.Property(e => e.Created)
    //            .HasDefaultValueSql("getdate()");
    //    }
    //}

    public class BaseModelConfiguration : IEntityTypeConfiguration<BaseModel>
    {
        public void Configure(EntityTypeBuilder<BaseModel> modelBuilder)
        {
            modelBuilder.Property(e => e.Created)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Property(e => e.Updated)
                .ValueGeneratedOnUpdate();
        }
    }
}
