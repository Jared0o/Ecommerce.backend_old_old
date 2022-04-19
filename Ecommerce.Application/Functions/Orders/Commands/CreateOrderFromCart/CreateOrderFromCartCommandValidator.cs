using FluentValidation;

namespace Ecommerce.Application.Functions.Orders.Commands.CreateOrderFromCart
{
    public class CreateOrderFromCartCommandValidator : AbstractValidator<CreateOrderFromCartCommand>
    {
        public CreateOrderFromCartCommandValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.AdressId).NotNull().NotEmpty();
        }
    }
}
