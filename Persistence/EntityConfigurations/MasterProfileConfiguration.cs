using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MasterProfileConfiguration : IEntityTypeConfiguration<MasterProfile>
{
    public void Configure(EntityTypeBuilder<MasterProfile> builder)
    {
        builder.ToTable("MasterProfiles").HasKey(key => key.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.Adress).HasColumnName("Adress").IsRequired();
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(sc => sc.IsActive).HasColumnName("IsActive").IsRequired();

        builder.HasMany(sc => sc.MasterWorkPhotos);

        builder.HasQueryFilter(filter => !filter.DeletedDate.HasValue);
    }
}
