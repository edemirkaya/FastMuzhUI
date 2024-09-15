namespace Application.Features.ServiceCategories.Queries.GetById;

public class GetByIdServiceCategoryResponse
{
    public Guid Id { get; set; }
    public Guid? SubServiceCategoryId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
