namespace Application.Features.ServiceCategories.Queries.GetListByDynamic;

public class GetListByDynamicServiceCategoryListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentServiceCategoryId { get; set; }
}
