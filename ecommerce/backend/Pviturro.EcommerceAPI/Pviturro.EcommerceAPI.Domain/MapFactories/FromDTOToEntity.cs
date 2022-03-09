using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.MapFactories
{
    public static class FromDTOToEntity
    {
        public static CategoryEntity Map(this Category dto)
        {
            if (dto == null) return new CategoryEntity();
            return new CategoryEntity { Id = dto.Id, Description = dto.Description, Name = dto.Name, Products = dto.Products != null ?  dto.Products.Select(_ => _.Map()).ToList() : new List<ProductEntity>() };
        }

        public static ProductEntity Map(this Product dto)
        {
            if (dto == null) return new ProductEntity();
            return new ProductEntity { Id = dto.Id, Category = dto.Category.Map(), Description = dto.Description, Name = dto.Name, price = dto.Price };
        }

        public static ShoppingCartEntity Map(this ShoppingCart dto)
        {
            if (dto == null) return new ShoppingCartEntity();
            return new ShoppingCartEntity { Id = dto.Id, Email = dto.Email, Product = dto.Product.Map(), Quantity = dto.Quantity };
        }
    }
}
