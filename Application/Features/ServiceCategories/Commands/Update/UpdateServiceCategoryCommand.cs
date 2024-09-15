using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ServiceCategories.Commands.Update;

public class UpdateServiceCategoryCommand:IRequest<UpdateServiceCategoryResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateServiceCategoryCommandHandler : IRequestHandler<UpdateServiceCategoryCommand, UpdateServiceCategoryResponse>
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateServiceCategoryCommandHandler(IServiceCategoryRepository serviceCategoryRepository, IMapper mapper)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _mapper = mapper;
        }
        public async Task<UpdateServiceCategoryResponse> Handle(UpdateServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            ServiceCategory? serviceCategory = await _serviceCategoryRepository.GetAsync(predicate : sc=> sc.Id == request.Id, cancellationToken : cancellationToken);

            serviceCategory = _mapper.Map(request, serviceCategory);
            await _serviceCategoryRepository.UpdateAsync(serviceCategory);

            var response =  _mapper.Map<UpdateServiceCategoryResponse>(serviceCategory);

            return response;
        }
    }
}
