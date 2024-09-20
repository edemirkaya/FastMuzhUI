using Application.Features.MasterProfiles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.MasterProfiles.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<MasterProfile,GetListMasterProfileListItemDto>().ReverseMap();
        CreateMap<Paginate<MasterProfile>,GetListResponse<GetListMasterProfileListItemDto>>().ReverseMap();
    }
}
