using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using Pviturro.EcommerceAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.ServiceLibrary
{
    public class EcommerceService : IEcommerceService
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IShoppingCartService _cartService;
        public EcommerceService(IProductService productService, ICategoryService categoryService, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _cartService = shoppingCartService;
        }

        public void AddCategory(Category categoryToAdd)
        {
            _categoryService.AddCategory(categoryToAdd);
        }

        public void AddProduct(Product productToAdd)
        {
            _productService.AddProduct(productToAdd);
        }

        public void AddProductToCart(ShoppingCart cartItem)
        {
            if(_productService.GetProductById(cartItem.ProductId) != null)
            {
                _cartService.AddProductToCart(cartItem);
                return;
            }
            throw new Exception();
        }

        public void DeleteCategory(int id)
        {
            if(_categoryService.GetCategoryById(id) != null)
            {
                _categoryService.DeleteCategory(id);
                return;
            }
            throw new Exception();
        }

        public void DeleteProduct(int id)
        {
            if(_productService.GetProductById(id) != null)
            {
                _productService.DeleteProduct(id);
                return;
            }
            throw new Exception();
        }

        public void DeleteProductFromCart(int id, string email)
        {
            if(_productService.GetProductById(id) != null
                && _cartService.SomeoneContainsProduct(email, id))
            {
                _cartService.DeleteProductFromSomeonesCart(email, id);
                return;
            }
            throw new Exception();
        }

        public void EmptyCart()
        {
            _cartService.EmptyCart();
        }

        public List<Category> GetCategories()
        {
            return _categoryService.GetCategories();    
        }

        public Category GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        public Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            if(_categoryService.GetCategoryById(id) != null)
            {
                return _productService.GetProductsByCategoryId(id);
            }
            throw new Exception();
        }

        public void UpdateCategory(int id, Category categoryUpdated)
        {
            if(_categoryService.GetCategoryById(id) != null)
            {
                _categoryService.UpdateCategory(id, categoryUpdated);
                return;
            }
            throw new Exception();
        }

        public void UpdateProduct(int id, Product productToUpdate)
        {
            if (_productService.GetProductById(id) != null)
            {
                _productService.UpdateProduct(id, productToUpdate);
                return;
            }
            throw new Exception();
        }

        public void UpdateProductInCart(int id, int quantity, string email)
        {
            if (_productService.GetProductById(id) != null
    && _cartService.SomeoneContainsProduct(email, id))
            {
                _cartService.UpdateProductInCart(id, quantity, email);
                return;
            }
            throw new Exception();
        }
    }
}
