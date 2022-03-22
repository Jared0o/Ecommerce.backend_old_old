using FluentValidation;

namespace Ecommerce.Application.Functions.Adresses.Queries.GetUserAdresses
{
    public class GetUserAdressesQueryValidator : AbstractValidator<GetUserAdressesQuery>
    {
        public GetUserAdressesQueryValidator()
        {
            RuleFor(x => x.UserEmail)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be valid");
        }
    }
}
