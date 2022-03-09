using Pviturro.EcommerceAPI.Domain.Models.Entities;
using Pviturro.EcommerceAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Infrastructure.Repositories
{
    public class EcommerceRepository : IEcommerceRepository
    {
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private IShoppingCartRepository _shoppingCartRepository;
        private EcommerceContext _context;

        public EcommerceRepository(ICategoryRepository categoryRepository, IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, EcommerceContext context)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _context = context;
        }

        public void CreateCategory(CategoryEntity categoryEntity)
        {
            _categoryRepository.CreateCategory(categoryEntity);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            _context.SaveChanges();
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
            _context.SaveChanges();
        }

        public void CreateProduct(ProductEntity productEntity)
        {
            _productRepository.CreateProduct(productEntity);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            _context.SaveChanges();
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
            if (_categoryRepository.GetCategoryById(id) != null)
            {
                return _productRepository.GetAllProductsByCategory(id);
            }
            throw new Exception();
        }

        public void UpdateProduct(int id, ProductEntity productEntity)
        {
            _productRepository.UpdateProduct(id, productEntity);
            _context.SaveChanges();
        }

        public void AddProductToCart(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                _shoppingCartRepository.AddProductToCart(id, product);
                _context.SaveChanges();
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
                _context.SaveChanges();
                return;
            }
            throw new Exception();
        }

        public void EmptyCart()
        {
            _shoppingCartRepository.EmptyCart();
            _context.SaveChanges();
        }

        public void UpdateProductInCart(int id, int quantity)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null && _shoppingCartRepository.IsProductInCart(id))
            {
                _shoppingCartRepository.UpdateProductInCart(id, quantity);
                _context.SaveChanges();
                return;
            }
            throw new Exception();
        }
    }
}
