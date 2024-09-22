/*
    - Müşteri tarfından açılan iş ilanına başvurabilecek nitelikteki ustadır.
    

    - Ustaya ait adı soyadı 
    - Ustaya ait Profil bilgileri virtual MasterProfile

 */
using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Master : Entity<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }


    public Guid? MasterProfileId { get; set; }
    public virtual MasterProfile? MasterProfiles { get; set; }
}
