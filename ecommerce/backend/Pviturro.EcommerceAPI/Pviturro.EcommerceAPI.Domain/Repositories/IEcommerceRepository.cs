using Microsoft.EntityFrameworkCore;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Repositories
{
    public interface IEcommerceRepository
    {
        void CreateCategory(CategoryEntity categoryEntity);
        void DeleteCategory(int id);
        List<CategoryEntity> GetAllCategories();
        CategoryEntity GetCategoryById(int id);
        void UpdateCategory(int id, CategoryEntity categoryEntity);
        void CreateProduct(ProductEntity productEntity);
        void DeleteProduct(int id);
        ProductEntity GetProductById(int id);
        List<ProductEntity> GetAllProducts();
        List<ProductEntity> GetAllProductsByCategory(int id);
        void UpdateProduct(int id, ProductEntity productEntity);
        void AddProductToCart(int id);
        bool IsProductInCart(int id);
        void DeleteProductFromCart(int id);
        void EmptyCart();
        void UpdateProductInCart(int id, int quantity);
    }
}
