using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MasterWorkPhotoRepository : EfRepositoryBase<MasterWorkPhoto, Guid, BaseDbContext>, IMasterWorkPhotoRepository
{
    public MasterWorkPhotoRepository(BaseDbContext dbcontext) : base(dbcontext)
    {
    }
}