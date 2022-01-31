using MediatR;

namespace Ecommerce.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
