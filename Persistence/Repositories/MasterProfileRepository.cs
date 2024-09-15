using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MasterProfileRepository : EfRepositoryBase<MasterProfile, Guid, BaseDbContext>, IMasterProfileRepository
{
    public MasterProfileRepository(BaseDbContext dbcontext) : base(dbcontext)
    {
    }
}
