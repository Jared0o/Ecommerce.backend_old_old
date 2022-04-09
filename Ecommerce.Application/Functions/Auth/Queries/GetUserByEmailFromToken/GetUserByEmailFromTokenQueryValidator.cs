using FluentValidation;

namespace Ecommerce.Application.Functions.Auth.Queries.GetUserByEmailFromToken
{
    public class GetUserByEmailFromTokenQueryValidator : AbstractValidator<GetUserByEmailFromTokenQuery>
    {
        public GetUserByEmailFromTokenQueryValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be valid");
        }
    }
}
