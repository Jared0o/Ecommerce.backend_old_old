using MediatR;

namespace Ecommerce.Application.Functions.Categories.Commands.AddCategoryToCategory
{
    public class AddCategoryToCategoryCommand : IRequest
    {
        public int ParentCategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public AddCategoryToCategoryCommand(int parentId, int childId)
        {
            ParentCategoryId = parentId;
            SubcategoryId = childId;
        }
    }
}
