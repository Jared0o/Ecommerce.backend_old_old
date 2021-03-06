using Ecommerce.Application.Functions.Categories.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CategoryBaseDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public UpdateCategoryCommand(int id, string name, string description, bool isActive)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}
