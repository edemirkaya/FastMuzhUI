namespace Application.Features.ServiceCategories.Commands.Create;

public class CreateServiceCategoryResponse
{
    public Guid Id { get; set; }
    public Guid? ParentServiceCategoryId { get; set; }
    public string Name { get; set; }
}
