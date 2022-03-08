using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.MapFactories
{
    public static class FromEntityToDTO
    {
        public static Category Map(this CategoryEntity entity)
        {
            return new Category { Id = entity.Id, Description = entity.Description, Name = entity.Name, Products = entity.Products.Select(_ => _.Map()).ToList()};
        }

        public static Product Map(this ProductEntity entity)
        {
            return new Product { Id = entity.Id, Category = entity.Category.Map(), CategoryId = entity.Category.Id, Description = entity.Description, Name = entity.Name, Price = entity.price };
        }

        public static ShoppingCart Map(this ShoppingCartEntity entity)
        {
            return new ShoppingCart { Id = entity.Id, Email = entity.Email, Product = entity.Product.Map(), ProductId = entity.Product.Id, Quantity = entity.Quantity };
        }
    }
}
