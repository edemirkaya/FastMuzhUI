using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MasterWorkPhotoConfiguration : IEntityTypeConfiguration<MasterWorkPhoto>
{
    public void Configure(EntityTypeBuilder<MasterWorkPhoto> builder)
    {
        builder.ToTable("MasterWorkPhotos").HasKey(key => key.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.Name).HasColumnName("Name").IsRequired();
        builder.Property(sc => sc.Explanation).HasColumnName("Explanation").IsRequired();
        builder.Property(sc => sc.Url).HasColumnName("Url").IsRequired();
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(sc => sc.IsActive).HasColumnName("IsActive").IsRequired();

        builder.HasOne(sc => sc.Master);

        builder.HasQueryFilter(filter => !filter.DeletedDate.HasValue);
    }
}
