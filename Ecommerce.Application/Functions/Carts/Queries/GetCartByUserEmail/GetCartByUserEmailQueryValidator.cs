using FluentValidation;

namespace Ecommerce.Application.Functions.Carts.Queries.GetCartByUserEmail
{
    internal class GetCartByUserEmailQueryValidator : AbstractValidator<GetCartByUserEmailQuery>
    {
        public GetCartByUserEmailQueryValidator()
        {
            RuleFor(x => x.UserEmail)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
        }
    }
}
