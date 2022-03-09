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

        public void AddProductToCart(int id)
        {
            _context.AddProductToCart(id);
        }

        public bool ContainsProduct(int id)
        {
            return _context.IsProductInCart(id);
        }

        public void DeleteProductFromCart(int id)
        {
            _context.DeleteProductFromCart(id);
        }

        public void EmptyCart()
        {
            _context.EmptyCart();
        }

        public void UpdateProductInCart(int id, int quantity)
        {
            _context.UpdateProductInCart(id, quantity);
        }
    }
}
