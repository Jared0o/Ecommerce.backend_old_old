using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Functions.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQueryValidator : AbstractValidator<GetBrandByIdQuery>
    {
        public GetBrandByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
