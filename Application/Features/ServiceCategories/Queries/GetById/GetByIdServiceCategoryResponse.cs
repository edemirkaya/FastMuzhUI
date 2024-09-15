namespace Application.Features.ServiceCategories.Queries.GetById;

public class GetByIdServiceCategoryResponse
{
    public Guid Id { get; set; }
    public Guid? SubServiceCategoryId { get; set; }
    public string Name { get; set; }
}
