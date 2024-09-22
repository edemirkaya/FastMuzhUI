namespace Application.Features.ServiceCategories.Queries.GetList;

public class GetListServiceCategoryListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentServiceCategoryId { get; set; } 
}
