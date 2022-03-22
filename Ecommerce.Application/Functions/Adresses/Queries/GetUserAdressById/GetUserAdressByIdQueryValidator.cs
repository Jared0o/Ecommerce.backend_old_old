using FluentValidation;

namespace Ecommerce.Application.Functions.Adresses.Queries.GetUserAdressById
{
    public class GetUserAdressByIdQueryValidator : AbstractValidator<GetUserAdressByIdQuery>
    {
        public GetUserAdressByIdQueryValidator()
        {
            RuleFor(x => x.AdressId).NotEmpty().NotNull();

            RuleFor(x => x.UserEmail)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be valid");
        }
    }
}
