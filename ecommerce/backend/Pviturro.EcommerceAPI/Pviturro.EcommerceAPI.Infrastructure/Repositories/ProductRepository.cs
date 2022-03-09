using Microsoft.EntityFrameworkCore;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using Pviturro.EcommerceAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DbSet<ProductEntity> _products;

        public ProductRepository(EcommerceContext context)
        {
            _products = context.Products;
        }

        public void CreateProduct(ProductEntity productEntity)
        {
            productEntity.Id = 0;
            _products.Add(productEntity);
        }

        public void DeleteProduct(int id)
        {
            var product = _products.Find(id); 
            if(product != null)
            {
                _products.Remove(product);
                return;
            }
            throw new Exception();
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _products.ToList();
        }

        public List<ProductEntity> GetAllProductsByCategory(int id)
        {
            return _products.Where(_ => _.Category.Id == id).ToList();
        }

        public ProductEntity GetProductById(int id)
        {
            return _products.Find(id);
        }

        public void UpdateProduct(int id, ProductEntity productEntity)
        {
            var targetProduct = _products.Find(id);
            if(targetProduct != null)
            {
                targetProduct.Category = productEntity.Category;
                targetProduct.Description = productEntity.Description;
                targetProduct.Name = productEntity.Name;
                targetProduct.price = productEntity.price;
                return;
            }
            throw new Exception();
        }
    }
}
