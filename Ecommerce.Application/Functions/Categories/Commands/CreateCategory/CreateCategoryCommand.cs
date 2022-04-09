using Ecommerce.Application.Functions.Categories.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryBaseDto>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public CreateCategoryCommand(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
