using AutoMapper;
using Ecommerce.Application.Functions.Adresses.Commands;
using Ecommerce.Application.Functions.Adresses.Commands.UpdateAdress;
using Ecommerce.Application.Functions.Adresses.Responses;
using Ecommerce.Application.Functions.Brands.Commands.CreateBrand;
using Ecommerce.Application.Functions.Brands.Commands.UpdateBrand;
using Ecommerce.Application.Functions.Brands.Responses;
using Ecommerce.Application.Functions.Carts.Responses;
using Ecommerce.Application.Functions.Categories.Commands.CreateCategory;
using Ecommerce.Application.Functions.Categories.Commands.UpdateCategory;
using Ecommerce.Application.Functions.Categories.Responses;
using Ecommerce.Application.Functions.Products.Commands;
using Ecommerce.Application.Functions.Products.Commands.UpdateProduct;
using Ecommerce.Application.Functions.Products.Responses;
using Ecommerce.Application.Functions.Taxes.Commands.CreateTax;
using Ecommerce.Application.Functions.Taxes.Commands.UpdateTax;
using Ecommerce.Application.Functions.Taxes.Responses;
using Ecommerce.Application.Functions.Users.Commands.RegisterUser;
using Ecommerce.Application.Functions.Users.Responses;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryBaseDto>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Tax, TaxBaseDto>();
            CreateMap<CreateTaxCommand, Tax>();
            CreateMap<UpdateTaxCommand, Tax>();
            CreateMap<Product, ProductBaseDto>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<User, UserBaseDto>();
            CreateMap<RegisterUserCommand, User>();
            CreateMap<Adress, AdressBaseDto>();
            CreateMap<CreateAdressCommand, Adress>();
            CreateMap<UpdateAdressCommand, Adress>();
            CreateMap<Brand, BrandBaseResponse>();
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<UpdateBrandCommand, Brand>();
            CreateMap<Cart, CartBaseResponse>();
        }
    }
}
