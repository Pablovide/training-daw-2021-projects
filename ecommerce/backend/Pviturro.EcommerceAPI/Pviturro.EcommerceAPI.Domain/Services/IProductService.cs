using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Services
{
    public interface IProductService
    {
        void AddProduct(Product productToAdd);
        Product GetProductById(int id);
        void DeleteProduct(int id);
        List<Product> GetProducts();
    }
}
