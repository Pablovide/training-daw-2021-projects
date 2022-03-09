using Pviturro.EcommerceAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Repositories
{
    public interface IProductRepository
    {
        void CreateProduct(ProductEntity productEntity);
        void DeleteProduct(int id);
        ProductEntity GetProductById(int id);
        List<ProductEntity> GetAllProducts();
        List<ProductEntity> GetAllProductsByCategory(int id);
        void UpdateProduct(int id, ProductEntity productEntity);
    }
}
