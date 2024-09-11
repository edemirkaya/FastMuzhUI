using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ServiceCategories.Commands.Create;

public class CreateServiceCategoryCommand:IRequest<CreateServiceCategoryResponse>
{
    public Guid? SubServiceCategoryId { get; set; }
    public string Name { get; set; }

    public class CreateServiceCategoryCommandHandler : IRequestHandler<CreateServiceCategoryCommand, CreateServiceCategoryResponse>
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IMapper _mapper;

        public CreateServiceCategoryCommandHandler(IServiceCategoryRepository serviceCategoryRepository, IMapper mapper)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateServiceCategoryResponse>? Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            ServiceCategory serviceCategory = _mapper.Map<ServiceCategory>(request);    
            serviceCategory.Id = Guid.NewGuid();

            await _serviceCategoryRepository.AddAsync(serviceCategory);
            var response = _mapper.Map<CreateServiceCategoryResponse>(serviceCategory);
            return response;
        }
    }
}
