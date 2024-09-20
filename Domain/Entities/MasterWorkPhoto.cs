
using Core.Persistence.Repositories;
using System.Xml.Linq;
using System;

namespace Domain.Entities;

public class MasterWorkPhoto:Entity<Guid>
{
    public string Name { get; set; }
    public string Explanation { get; set; }
    public string Url { get; set; }
    public Guid MasterProfileId { get; set; }
    public Guid? WorkId { get; set; }
    public string WorkPhotoUrl{ get; set; }

    public virtual MasterProfile? MasterProfile { get; set; }

    public MasterWorkPhoto()
    {
        
    }
    public MasterWorkPhoto(string name,string explanation,string url):this()
    {
        Name = name;    
        Explanation = explanation;
        Url = url;
    }

    public MasterWorkPhoto(string name, string explanation, string url,Guid masterProfileId, Guid? workId):this(name, explanation, url)
    {
        MasterProfileId = masterProfileId;
        WorkId = workId;
    }
}
