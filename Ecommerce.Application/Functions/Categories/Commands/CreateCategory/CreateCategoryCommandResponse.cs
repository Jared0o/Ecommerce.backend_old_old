﻿namespace Ecommerce.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDisable { get; set; }
    }
}