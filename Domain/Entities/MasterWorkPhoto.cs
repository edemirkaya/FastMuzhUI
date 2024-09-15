
using Core.Persistence.Repositories;
using System.Xml.Linq;
using System;

namespace Domain.Entities;

public class MasterWorkPhoto:Entity<Guid>
{
    public string Name { get; set; }
    public string Explanation { get; set; }
    public string Url { get; set; }
    public Guid MasterId { get; set; }
    public Guid? WorkId { get; set; }
    public string WorkPhotoUrl{ get; set; }

    public virtual Master Master { get; set; }
    public virtual JobPost JobPost { get; set; }

    public MasterWorkPhoto(string name,string explanation,string url)
    {
        Name = name;    
        Explanation = explanation;
        Url = url;
    }

    public MasterWorkPhoto(string name, string explanation, string url,Guid masterId, Guid? workId):this(name, explanation, url)
    {
        MasterId = masterId;
        WorkId = workId;
    }
}
