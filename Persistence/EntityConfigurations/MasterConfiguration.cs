using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MasterConfiguration : IEntityTypeConfiguration<Master>
{
    public void Configure(EntityTypeBuilder<Master> builder)
    {
        builder.ToTable("Masters").HasKey(key => key.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.Name).HasColumnName("Name");
        builder.Property(sc => sc.Surname).HasColumnName("Surname");
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(sc => sc.IsActive).HasColumnName("IsActive").IsRequired();

        builder.HasOne(sc => sc.MasterProfiles);

        builder.HasQueryFilter(filter => !filter.DeletedDate.HasValue);
    }
}
