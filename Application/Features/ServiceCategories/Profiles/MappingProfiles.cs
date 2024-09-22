using Application.Features.ServiceCategories.Commands.Create;
using Application.Features.ServiceCategories.Commands.Delete;
using Application.Features.ServiceCategories.Commands.Update;
using Application.Features.ServiceCategories.Queries.GetById;
using Application.Features.ServiceCategories.Queries.GetList;
using Application.Features.ServiceCategories.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ServiceCategories.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<ServiceCategory, CreateServiceCategoryCommand>().ReverseMap();
        CreateMap<ServiceCategory, CreateServiceCategoryResponse>().ReverseMap();

        CreateMap<ServiceCategory, UpdateServiceCategoryResponse>().ReverseMap();
        CreateMap<ServiceCategory, UpdateServiceCategoryCommand>().ReverseMap();

        CreateMap<ServiceCategory, DeleteServiceCategoryResponse>().ReverseMap();
        CreateMap<ServiceCategory, DeleteServiceCategoryCommand>().ReverseMap();

        CreateMap<ServiceCategory, GetListServiceCategoryListItemDto>().ReverseMap();
        CreateMap<ServiceCategory, GetListByDynamicServiceCategoryListItemDto>().ReverseMap();
        CreateMap<Paginate<ServiceCategory>, GetListResponse<GetListServiceCategoryListItemDto>>().ReverseMap();
        CreateMap<Paginate<ServiceCategory>, GetListResponse<GetListByDynamicServiceCategoryListItemDto>>().ReverseMap();

        CreateMap<ServiceCategory, GetByIdServiceCategoryResponse>().ReverseMap();

        
    }
}
