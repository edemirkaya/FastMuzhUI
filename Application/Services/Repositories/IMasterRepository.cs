using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IMasterRepository : IAsyncRepository<Master, Guid>
{
}
