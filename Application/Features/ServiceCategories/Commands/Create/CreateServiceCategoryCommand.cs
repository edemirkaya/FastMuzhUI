using MediatR;

namespace Application.Features.ServiceCategories.Commands.Create;

public class CreateServiceCategoryCommand:IRequest<CreateServiceCategoryResponse>
{
    public Guid SubServiceCategoryId { get; set; }
    public string Name { get; set; }

    public class CreateServiceCategoryCommandHandler : IRequestHandler<CreateServiceCategoryCommand, CreateServiceCategoryResponse>
    {
        public Task<CreateServiceCategoryResponse>? Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateServiceCategoryResponse();
            response.Id = new Guid();
            response.SubServiceCategoryId = request.SubServiceCategoryId;
            response.Name = request.Name;

            return null;
        }
    }
}
