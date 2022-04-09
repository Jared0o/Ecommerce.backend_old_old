using FluentValidation;

namespace Ecommerce.Application.Functions.Users.Commands.RegisterUser
{
    internal class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be valid");

            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(8).WithMessage("Minimal length for {PropertyName} is {MinLength}. You entered {TotalLength} characters")
                .Matches("[A-Z]").WithMessage("{PropertyName} must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("{PropertyName} must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("{PropertyName} must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("{PropertyName} must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("{PropertyName} must not contain the following characters £ # “” or spaces.");
        }

        //Todo more validators
    }
}
