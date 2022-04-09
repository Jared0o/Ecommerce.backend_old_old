using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Functions.Auth.Queries.LoginUser
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be valid");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(8).WithMessage("Minimal length for {PropertyName} is {MinLength}. You entered {TotalLength} characters")
                .Matches("[A-Z]").WithMessage("{PropertyName} must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("{PropertyName} must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("{PropertyName} must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("{PropertyName} must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("{PropertyName} must not contain the following characters £ # “” or spaces.");
        }
    }
}
