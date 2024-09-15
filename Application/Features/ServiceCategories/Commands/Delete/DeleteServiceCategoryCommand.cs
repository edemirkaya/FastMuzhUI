using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ServiceCategories.Commands.Delete;

public class DeleteServiceCategoryCommand : IRequest<DeleteServiceCategoryResponse>
{
    public Guid Id{ get; set; }

    public class DeleteServiceCategoryCommandHandler:IRequestHandler<DeleteServiceCategoryCommand,DeleteServiceCategoryResponse>
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IMapper _mapper;

        public DeleteServiceCategoryCommandHandler(IServiceCategoryRepository serviceCategoryRepository, IMapper mapper)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _mapper = mapper;
        }

        public async Task<DeleteServiceCategoryResponse> Handle(DeleteServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            ServiceCategory? serviceCategory = await _serviceCategoryRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);

            await _serviceCategoryRepository.DeleteAsync(serviceCategory);

            DeleteServiceCategoryResponse deleteServiceCategoryResponse = _mapper.Map<DeleteServiceCategoryResponse>(serviceCategory);

            return deleteServiceCategoryResponse;
        }
    }
}
