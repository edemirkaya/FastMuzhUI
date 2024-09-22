using Application.Features.ServiceCategories.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ServiceCategories.Queries.GetListByDynamic;

public class GetListByDynamicServiceCategoryQuery : IRequest<GetListResponse<GetListByDynamicServiceCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicServiceCategoryQueryHandler : IRequestHandler<GetListByDynamicServiceCategoryQuery, GetListResponse<GetListByDynamicServiceCategoryListItemDto>>
    {
        private readonly IServiceCategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetListByDynamicServiceCategoryQueryHandler(IServiceCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDynamicServiceCategoryListItemDto>> Handle(GetListByDynamicServiceCategoryQuery request, CancellationToken cancellationToken)
        {
            Paginate<ServiceCategory> serviceCategories = await _repository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                include: m => m.Include(i => i.ParentServiceCategories),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            GetListResponse<GetListByDynamicServiceCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicServiceCategoryListItemDto>>(serviceCategories);
            return response;
        }
    }
}

