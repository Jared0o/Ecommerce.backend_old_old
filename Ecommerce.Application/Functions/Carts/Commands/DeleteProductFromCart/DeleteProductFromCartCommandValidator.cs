using FluentValidation;

namespace Ecommerce.Application.Functions.Carts.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartCommandValidator : AbstractValidator<DeleteProductFromCartCommand>
    {
        public DeleteProductFromCartCommandValidator()
        {
            RuleFor(x => x.CartProductId).NotEmpty().NotNull();
            RuleFor(x => x.UserEmail).NotEmpty().NotNull().EmailAddress();
        }
    }
}
