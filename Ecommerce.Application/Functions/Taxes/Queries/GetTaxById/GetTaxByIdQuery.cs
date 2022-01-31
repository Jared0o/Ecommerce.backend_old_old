using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Functions.Taxes.Queries.GetTaxById
{
    public class GetTaxByIdQuery : IRequest<GetTaxByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
