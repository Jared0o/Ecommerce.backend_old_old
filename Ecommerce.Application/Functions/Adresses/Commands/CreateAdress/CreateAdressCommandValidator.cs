using FluentValidation;
using System.Text.RegularExpressions;

namespace Ecommerce.Application.Functions.Adresses.Commands
{
    public class CreateAdressCommandValidator : AbstractValidator<CreateAdressCommand>
    {
        public CreateAdressCommandValidator()
        {
            RuleFor(adr => adr.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be valid");

            RuleFor(adr => adr.Telephone)
                .NotEmpty()
                .NotNull().WithMessage("Phone Number is required.")
                .Length(9).WithMessage("Phone length must be 9")
                .Matches(new Regex(@"^\d{9}$")).WithMessage("Phone Number not valid");

            RuleFor(adr => adr.Name)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MinimumLength(5).WithMessage("{PropertyName} must not be less than 5 characters.")
                .MaximumLength(80).WithMessage("{PropertyName} must not exceed 80 characters.");

            RuleFor(adr => adr.Country)
                 .NotNull().WithMessage("{PropertyName} is required.")
                 .MinimumLength(4).WithMessage("{PropertyName} must not be less than 5 characters.")
                 .MaximumLength(80).WithMessage("{PropertyName} must not exceed 80 characters.");

            RuleFor(adr => adr.City)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MinimumLength(4).WithMessage("{PropertyName} must not be less than 4 characters.")
                .MaximumLength(80).WithMessage("{PropertyName} must not exceed 80 characters.");

            RuleFor(adr => adr.Street)
                .NotNull().WithMessage("Street is required.")
                .MinimumLength(5).WithMessage("Street must not be less than 5 characters.")
                .MaximumLength(80).WithMessage("Street must not exceed 80 characters.");

            RuleFor(adr => adr.HouseNumber)
                .NotNull().WithMessage("Street is required.")
                .MinimumLength(1).WithMessage("Street must not be less than 1 characters.")
                .MaximumLength(10).WithMessage("Street must not exceed 10 characters.");

            RuleFor(adr => adr.ZipCode)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .Length(5).WithMessage("{PropertyName} length must be 5")
                .Matches(new Regex(@"^\d{5}$")).WithMessage("{PropertyName}  not valid");

        }
    }
}
