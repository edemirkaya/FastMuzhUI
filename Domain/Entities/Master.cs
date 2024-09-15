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

    public virtual MasterProfile? MasterProfile { get; set; }
    public virtual ICollection<MasterWorkPhoto>? MasterWorkPhotos { get; set; }

    public Master()
    {
        MasterWorkPhotos = new HashSet<MasterWorkPhoto>();
    }
    public Master(string name, string surname):this()
    {
        Name = name;
        Surname = surname;
    }
    public Master(string name, string surname, MasterProfile? masterProfile) : this(name, surname)
    {
        MasterProfile = masterProfile;
    }
    public Master(string name, string surname, MasterProfile? masterProfile, ICollection<MasterWorkPhoto>? masterWorkPhotos) : this(name, surname)
    {
        MasterProfile = masterProfile;
        MasterWorkPhotos = masterWorkPhotos;
    }
}
