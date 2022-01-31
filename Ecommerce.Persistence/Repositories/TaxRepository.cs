using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    internal class TaxRepository : BaseRepository<Tax>, ITaxRepository
    {
        public TaxRepository(EcommerceContext context) : base(context)
        {
        }
    }
}
