using FluentValidation;

namespace Ecommerce.Application.Functions.Orders.Queries.GetUserOrdersList
{
    public class GetUserOrdersQueryValidator : AbstractValidator<GetUserOrdersQuery>
    {
        public GetUserOrdersQueryValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().NotNull().EmailAddress();
        }
    }
}
