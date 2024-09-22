using Application.Features.ServiceCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ServiceCategories.Commands.Create;

public class CreateServiceCategoryCommand:IRequest<CreateServiceCategoryResponse>
{
    public Guid? ParentServiceCategoryId { get; set; }
    public string Name { get; set; }

    public class CreateServiceCategoryCommandHandler : IRequestHandler<CreateServiceCategoryCommand, CreateServiceCategoryResponse>
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ServiceCategoryBusinessRules _serviceCategoryBusinessRules;

        public CreateServiceCategoryCommandHandler(IServiceCategoryRepository serviceCategoryRepository, IMapper mapper, ServiceCategoryBusinessRules serviceCategoryBusinessRules)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _mapper = mapper;
            _serviceCategoryBusinessRules = serviceCategoryBusinessRules;
        }

        public async Task<CreateServiceCategoryResponse>? Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            await _serviceCategoryBusinessRules.ServiceCategoryCannotBeDuplicatedWhenInsert(request.Name);

            ServiceCategory serviceCategory = _mapper.Map<ServiceCategory>(request);    
            serviceCategory.Id = Guid.NewGuid();

            await _serviceCategoryRepository.AddAsync(serviceCategory);

            var response = _mapper.Map<CreateServiceCategoryResponse>(serviceCategory);
            return response;
        }
    }
}
