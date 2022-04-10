using FluentValidation;

namespace Ecommerce.Application.Functions.Carts.Commands.DeleteAllProductsFromCart
{
    internal class DeleteAllProductsFromCartCommandValidator : AbstractValidator<DeleteAllProductsFromCartCommand>
    {
        public DeleteAllProductsFromCartCommandValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().NotNull().EmailAddress();
        }
    }
}
