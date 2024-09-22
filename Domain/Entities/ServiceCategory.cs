/*
    - Sistemde sunulan hizmetlerin Listesidir. Nested sonsuz kırılımlı br yapıya sahiptir.
 */
using Core.Persistence.Repositories;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Domain.Entities;

public class ServiceCategory : Entity<Guid>
{
    public string Name { get; set; }


    public Guid? ParentServiceCategoryId { get; set; }
    public virtual ICollection<ServiceCategory>? ParentServiceCategories { get; set; }
    public virtual ICollection<MasterProfile> MasterProfiles { get; set; }
}
