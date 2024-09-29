using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ServiceCategories.Queries.GetList;

public class GetListServiceCategoryQuery : IRequest<GetListResponse<GetListServiceCategoryListItemDto>>, ICacheableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListServiceCategoryQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration { get; }

    public class GetListServiceCategoryQueryHandler : IRequestHandler<GetListServiceCategoryQuery, GetListResponse<GetListServiceCategoryListItemDto>>
    {
        private readonly IServiceCategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetListServiceCategoryQueryHandler(IServiceCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListServiceCategoryListItemDto>> Handle(GetListServiceCategoryQuery request, CancellationToken cancellationToken)
        {
            Paginate<ServiceCategory> serviceCategories = await _repository.GetListAsync(
                include: m => m.Include(i => i.ParentServiceCategories),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            GetListResponse<GetListServiceCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListServiceCategoryListItemDto>>(serviceCategories);
            return response;
        }
    }
}
