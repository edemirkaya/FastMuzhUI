
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class MasterWorkPhoto:Entity<Guid>
{
    public Guid MasterId { get; set; }
    public Guid? WorkId { get; set; }
    public string WorkPhotoUrl{ get; set; }

    public virtual Master Master { get; set; }
    public virtual JobPost JobPost { get; set; }

    public MasterWorkPhoto(Guid masterId, Guid? workId)
    {
        MasterId = masterId;
        WorkId = workId;
    }
}
