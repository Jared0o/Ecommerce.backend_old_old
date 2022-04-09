using FluentValidation;

namespace Ecommerce.Application.Functions.Carts.Commands.AddProductToCart
{
    internal class AddProductToCartCommandValidator : AbstractValidator<AddProductToCartCommand>
    {
        public AddProductToCartCommandValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.ProductId).NotNull().NotEmpty();
            RuleFor(x => x.ProductVariantId).NotNull().NotEmpty();
            RuleFor(x => x.Quantity).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
