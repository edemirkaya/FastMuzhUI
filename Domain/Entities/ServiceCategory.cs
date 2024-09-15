/*
    - Sistemde sunulan hizmetlerin Listesidir. Nested sonsuz kırılımlı br yapıya sahiptir.
 */
using Core.Persistence.Repositories;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Domain.Entities;

public class ServiceCategory : Entity<Guid>
{
    public Guid? ParentServiceCategoryId { get; set; } = Guid.Empty;
    public string Name { get; set; }

    public virtual ICollection<ServiceCategory> ParentServiceCategories { get; set; }

    public ServiceCategory()
    { }

    public ServiceCategory(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    public ServiceCategory(Guid id, string name, Guid? parentServiceCategoryId)
    {
        Id = id;
        ParentServiceCategoryId = parentServiceCategoryId;
        Name = name;
    }
}
