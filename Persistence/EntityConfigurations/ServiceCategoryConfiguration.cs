﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
{
    public void Configure(EntityTypeBuilder<ServiceCategory> builder)
    {
        builder.ToTable("ServiceCategories").HasKey(key => key.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.Name).HasColumnName("Name");
        builder.Property(sc => sc.ParentServiceCategoryId).HasColumnName("ParentServiceCategoryId");
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(sc => sc.IsActive).HasColumnName("IsActive").IsRequired();

        builder.HasOne<ServiceCategory>().WithMany(sc => sc.ParentServiceCategories).HasForeignKey(sc=> sc.ParentServiceCategoryId);

        builder.HasQueryFilter(filter => !filter.DeletedDate.HasValue);
    }
}