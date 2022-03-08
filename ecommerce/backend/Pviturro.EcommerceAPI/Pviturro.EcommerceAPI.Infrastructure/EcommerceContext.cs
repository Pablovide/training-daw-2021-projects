using Microsoft.EntityFrameworkCore;
using Pviturro.EcommerceAPI.Domain.Infrastructure;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using Pviturro.EcommerceAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Infrastructure
{
    public class EcommerceContext : DbContext, IEcommerceContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }

        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private IShoppingCartRepository _shoppingCartRepository;

        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }

        public void CreateCategory(CategoryEntity categoryEntity)
        {
            _categoryRepository.CreateCategory(categoryEntity);
            SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            SaveChanges();
        }

        public List<CategoryEntity> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public CategoryEntity GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public void UpdateCategory(int id, CategoryEntity categoryEntity)
        {
            _categoryRepository.UpdateCategory(id, categoryEntity);
            SaveChanges();
        }

        public void CreateProduct(ProductEntity productEntity)
        {
            _productRepository.CreateProduct(productEntity);
            SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            SaveChanges();
        }

        public ProductEntity GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public List<ProductEntity> GetAllProductsByCategory(int id)
        {
            if(_categoryRepository.GetCategoryById(id) != null)
            {
                return _productRepository.GetAllProductsByCategory(id);
            }
            throw new Exception();
        }

        public void UpdateProduct(int id, ProductEntity productEntity)
        {
            _productRepository.UpdateProduct(id, productEntity);
            SaveChanges();
        }

        public void AddProductToCart(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                _shoppingCartRepository.AddProductToCart(id, product);
                SaveChanges();
                return;
            }
            throw new Exception();
        }

        public bool IsProductInCart(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                return _shoppingCartRepository.IsProductInCart(id);
            }
            throw new Exception();
        }

        public void DeleteProductFromCart(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null && _shoppingCartRepository.IsProductInCart(id))
            {
                _shoppingCartRepository.DeleteProductFromCart(id);
                SaveChanges();
                return;
            }
            throw new Exception();
        }

        public void EmptyCart()
        {
            _shoppingCartRepository.EmptyCart();
            SaveChanges();
        }

        public void UpdateProductInCart(int id, int quantity)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null && _shoppingCartRepository.IsProductInCart(id))
            {
                _shoppingCartRepository.UpdateProductInCart(id, quantity);
                SaveChanges();
                return;
            }
            throw new Exception();
        }
    }
}
