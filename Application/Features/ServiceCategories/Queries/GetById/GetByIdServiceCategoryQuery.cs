using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ServiceCategories.Queries.GetById;

public class GetByIdServiceCategoryQuery : IRequest<GetByIdServiceCategoryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdServiceCategoryQueryHandler : IRequestHandler<GetByIdServiceCategoryQuery, GetByIdServiceCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;

        public GetByIdServiceCategoryQueryHandler(IMapper mapper, IServiceCategoryRepository serviceCategoryRepository)
        {
            _mapper = mapper;
            _serviceCategoryRepository = serviceCategoryRepository;
        }

        public async Task<GetByIdServiceCategoryResponse> Handle(GetByIdServiceCategoryQuery request, CancellationToken cancellationToken)
        {
            ServiceCategory serviceCategory = await _serviceCategoryRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdServiceCategoryResponse response = _mapper.Map<GetByIdServiceCategoryResponse>(serviceCategory);

            return response;
        }
    }
}
