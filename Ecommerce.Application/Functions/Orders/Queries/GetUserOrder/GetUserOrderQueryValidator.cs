using FluentValidation;

namespace Ecommerce.Application.Functions.Orders.Queries.GetUserOrder
{
    public class GetUserOrderQueryValidator : AbstractValidator<GetUserOrderQuery>
    {
        public GetUserOrderQueryValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.OrderId).NotNull().NotEmpty();
        }
    }
}
