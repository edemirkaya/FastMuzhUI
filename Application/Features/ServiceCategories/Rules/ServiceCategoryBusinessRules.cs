using Application.Features.ServiceCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConserns.Exceptions.Types;

namespace Application.Features.ServiceCategories.Rules;

public class ServiceCategoryBusinessRules:BaseBusinessRules
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public ServiceCategoryBusinessRules(IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceCategoryRepository = serviceCategoryRepository;
    }

    public async Task ServiceCategoryCannotBeDuplicatedWhenInsert(string serviceCategoryName)
    {
        var result = await _serviceCategoryRepository.GetAsync(predicate: sc => sc.Name.ToLower() == serviceCategoryName.ToLower());
        if (result != null)
        {
            throw new BusinessException(ServiceCategoryMessages.ServiceCategoryNameExist);
        }
    }
}
