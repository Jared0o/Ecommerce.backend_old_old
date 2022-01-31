using FluentValidation.Results;

namespace Ecommerce.Application.Exceptions
{
    public class ValidateException : ApplicationException
    {
        public int ErrorCount { get; set; }
        public List<string> Errors { get; set; }
        public ValidateException(ValidationResult validationResult)
        {
            ErrorCount = validationResult.Errors.Count;
            Errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }

        }
    }
}
