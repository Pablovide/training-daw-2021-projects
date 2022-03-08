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
            return new CategoryEntity { Id = dto.Id, Description = dto.Description, Name = dto.Name, Products = dto.Products.Select(_ => _.Map()).ToList() };
        }

        public static ProductEntity Map(this Product dto)
        {
            return new ProductEntity { Id = dto.Id, Category = dto.Category.Map(), Description = dto.Description, Name = dto.Name, price = dto.Price };
        }

        public static ShoppingCartEntity Map(this ShoppingCart dto)
        {
            return new ShoppingCartEntity { Id = dto.Id, Email = dto.Email, Product = dto.Product.Map(), Quantity = dto.Quantity };
        }
    }
}
