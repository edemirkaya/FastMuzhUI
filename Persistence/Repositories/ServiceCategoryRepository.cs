using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ServiceCategoryRepository : EfRepositoryBase<ServiceCategory, Guid, BaseDbContext>, IServiceCategoryRepository
{
    public ServiceCategoryRepository(BaseDbContext dbcontext) : base(dbcontext)
    {
    }
}