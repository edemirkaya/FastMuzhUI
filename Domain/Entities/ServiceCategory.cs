using Core.Persistence.Repositories;
using System.Reflection.Metadata;

namespace Domain.Entities;

public class ServiceCategory:Entity<Guid>
{
    public Guid SubServiceCategory { get; set; }
    public string Name { get; set; }

    public ServiceCategory()
    {}

    public ServiceCategory(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    public ServiceCategory(Guid id, Guid subServiceCategory,string name)
    {
        Id= id;
        SubServiceCategory = subServiceCategory;
        Name = name;
    }
}
