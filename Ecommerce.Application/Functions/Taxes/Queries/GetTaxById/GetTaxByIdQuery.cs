using Ecommerce.Application.Functions.Taxes.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Functions.Taxes.Queries.GetTaxById
{
    public class GetTaxByIdQuery : IRequest<TaxBaseDto>
    {
        public int Id { get; set; }

        public GetTaxByIdQuery(int id)
        {
            Id = id;
        }
    }
}
