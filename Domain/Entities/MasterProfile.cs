﻿/*
    -Ustaya ait ek bilgilerin tutulduğu tablodur.
    - Bir ustanın yaptığı işlerden topladığı puanların ortalaması bu tabloda tutulur. Point
    - Bir ustanın yeteneklerine göre vereceği hizmet bu entity üzerinden anlaşılır virtual ICollection<ServiceCategory>? ServiceCategories
    - Bir ustanın daha önce yaptığı işlerden müşterilerine göstermek istediği 10 örnek iş fotoğrafı bu tabloda tutulur. ICollection<MasterWorkPhoto>?
 * */
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class MasterProfile:Entity<Guid>
{
    public string Adress { get; set; }
    public string ProfilePhoto { get; set; }
    public decimal Point { get; set; }
    public Guid MasterId { get; set; }


    public virtual ICollection<ServiceCategory>? ServiceCategories { get; set; }
    public virtual ICollection<MasterWorkPhoto>? MasterWorkPhotos { get; set; }
    public virtual Master Master {  get; set; }

    public MasterProfile()
    { 
        ServiceCategories = new HashSet<ServiceCategory>();
        MasterWorkPhotos = new HashSet<MasterWorkPhoto>();
    }
        
    public MasterProfile(string adress, string profilePhoto, Guid masterId):this()
    {
        Adress = adress;
        ProfilePhoto = profilePhoto;
        MasterId = masterId;
    }
}
