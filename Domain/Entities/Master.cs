/*
    - Müşteri tarfından açılan iş ilanına başvurabilecek nitelikteki ustadır.
    

    - Ustaya ait adı soyadı 
    - Ustaya ait Profil bilgileri virtual MasterProfile
    - Ustanın daha önceki yaptığı işler den maks. 10 adet fotoğraf virtual MasterWorkPhotos

 */
using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Master :Entity<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public virtual MasterProfile? MasterProfiles { get; set; }


    public Master(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
    public Master(string name, string surname, MasterProfile? masterProfile) : this(name, surname)
    {
        MasterProfiles = masterProfile;
    }
}
