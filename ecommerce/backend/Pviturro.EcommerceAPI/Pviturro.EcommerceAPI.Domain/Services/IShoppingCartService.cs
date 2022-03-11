using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Services
{
    public interface IShoppingCartService
    {
        void AddProductToCart(ShoppingCart cartItem);
        bool ContainsProduct(int id);
        bool SomeoneContainsProduct(string email, int id);
        void DeleteProductFromCart(int id);
        void EmptyCart();
        void UpdateProductInCart(int id, int quantity, string email);
        void DeleteProductFromSomeonesCart(string email, int id);
    }
}
