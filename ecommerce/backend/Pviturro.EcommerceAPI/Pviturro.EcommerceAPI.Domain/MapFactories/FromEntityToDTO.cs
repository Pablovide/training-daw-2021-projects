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
            if (entity == null) return new Category();
            return new Category { Id = entity.Id, Description = entity.Description, Name = entity.Name};
        }

        public static Product Map(this ProductEntity entity)
        {
            if (entity == null) return new Product();
            return new Product { Id = entity.Id, CategoryId = entity.CategoryId, Description = entity.Description, Name = entity.Name, Price = entity.price };
        }

        public static ShoppingCart Map(this ShoppingCartEntity entity)
        {
            if (entity == null) return new ShoppingCart();
            return new ShoppingCart { Id = entity.Id, Email = entity.Email, Product = entity.Product.Map(), ProductId = entity.Product.Id, Quantity = entity.Quantity };
        }
    }
}
