using Pviturro.EcommerceAPI.Domain.MapFactories;
using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using Pviturro.EcommerceAPI.Domain.Repositories;
using Pviturro.EcommerceAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pviturro.EcommerceAPI.ServiceLibrary.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IEcommerceRepository _context;

        public ShoppingCartService(IEcommerceRepository context)
        {
            _context = context;
        }

        public void AddProductToCart(ShoppingCart cartItem)
        {
            _context.AddProductToCart(new ShoppingCartEntity() { Email = cartItem.Email, Id = cartItem.Id, Product = _context.GetProductById(cartItem.ProductId), Quantity = cartItem.Quantity});
        }

        public bool SomeoneContainsProduct(string email, int id)
        {
            return _context.IsProductInSomeonesCart(id, email);
        }

        public bool ContainsProduct(int id)
        {
            return _context.IsProductInWholeCart(id);
        }

        public void DeleteProductFromCart(int id)
        {
            _context.DeleteProductFromCart(id);
        }

        public void EmptyCart()
        {
            _context.EmptyCart();
        }

        public void UpdateProductInCart(int id, int quantity, string email)
        {
            _context.UpdateProductInCart(id, quantity, email);
        }
    }
}
