namespace Application.Features.ServiceCategories.Commands.Delete;

public class DeleteServiceCategoryResponse
{
    public Guid Id { get; set; }
    public Guid? SubServiceCategoryId { get; set; }
    public string Name { get; set; }
}
