﻿using Ecommerce.Application.Functions.Products.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductBaseDto>
    {
        public string Name { get; set; }
        public int TaxId { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public string? Sku { get; set; }
        public string? Brand { get; set; }
    }
}
