using FluentValidation;

namespace Application.Features.ServiceCategories.Commands.Create;

public class CreateServiceCategoryValidator:AbstractValidator<CreateServiceCategoryCommand>
{
    public CreateServiceCategoryValidator()
    {
        RuleFor(r=> r.Name).NotEmpty().MinimumLength(2);
    }
}
