using Pviturro.EcommerceAPI.Domain.MapFactories;
using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using Pviturro.EcommerceAPI.Domain.Repositories;
using Pviturro.EcommerceAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pviturro.EcommerceAPI.ServiceLibrary.Services
{
    public class ProductService : IProductService
    {
        private IEcommerceContext _context;
        public void AddProduct(Product productToAdd)
        {
            _context.CreateProduct(productToAdd.Map());
        }

        public void DeleteProduct(int id)
        {
            _context.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            return _context.GetProductById(id).Map();
        }

        public List<Product> GetProducts()
        {
            return _context.GetAllProducts().Select(_ => _.Map()).ToList();
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return _context.GetAllProductsByCategory(id).Select(_ => _.Map()).ToList();
        }

        public void UpdateProduct(int id, Product productToUpdate)
        {
            _context.UpdateProduct(id, productToUpdate.Map());
        }
    }
}
