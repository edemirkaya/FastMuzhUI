using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MasterRepository : EfRepositoryBase<Master, Guid, BaseDbContext>, IMasterRepository
{
    public MasterRepository(BaseDbContext dbcontext) : base(dbcontext)
    {
    }
}
