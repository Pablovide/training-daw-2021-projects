using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Services
{
    public interface IEcommerceService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category categoryToAdd);
        void UpdateCategory(int id, Category categoryUpdated);
        void DeleteCategory(int id);
        List<Product> GetProducts();
        Product GetProductById(int id);
        List<Product> GetProductsByCategoryId(int id);
        void AddProduct(Product productToAdd);
        void UpdateProduct(int id, Product productToUpdate);
        void DeleteProduct(int id);
        void AddProductToCart(ShoppingCart cartItem);
        void DeleteProductFromCart(int id);
        void UpdateProductInCart(int id, int quantity, string email);
        void EmptyCart();
    }
}
