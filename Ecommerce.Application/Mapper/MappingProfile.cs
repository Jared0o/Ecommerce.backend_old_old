using AutoMapper;
using Ecommerce.Application.Functions.Categories.Commands.CreateCategory;
using Ecommerce.Application.Functions.Categories.Commands.UpdateCategory;
using Ecommerce.Application.Functions.Categories.Queries.GetCategoryById;
using Ecommerce.Application.Functions.Categories.Queries.GetCategoryList;
using Ecommerce.Application.Functions.Products.Commands;
using Ecommerce.Application.Functions.Products.Commands.UpdateProduct;
using Ecommerce.Application.Functions.Taxes.Commands.CreateTax;
using Ecommerce.Application.Functions.Taxes.Commands.UpdateTax;
using Ecommerce.Application.Functions.Taxes.Queries.GetTaxById;
using Ecommerce.Application.Functions.Taxes.Queries.GetTaxList;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, GetCategoryListQueryResponse>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<Category, CreateCategoryCommandResponse>();
            CreateMap<Category, GetCategoryByIdQueryResponse>();
            CreateMap<Category, UpdateCategoryCommandResponse>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<CreateTaxCommand, Tax>();
            CreateMap<Tax, CreateTaxCommandResponse>();
            CreateMap<UpdateTaxCommand, Tax>();
            CreateMap<Tax, UpdateTaxCommandResponse>();
            CreateMap<Tax, GetTaxByIdQueryResponse>();
            CreateMap<Tax, GetTaxListQueryResponse>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductCommandResponse>();
            CreateMap<Product, UpdateProductCommandResponse>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
