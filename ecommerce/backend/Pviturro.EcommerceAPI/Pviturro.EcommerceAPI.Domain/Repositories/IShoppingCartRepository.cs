using Pviturro.EcommerceAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Repositories
{
    public interface IShoppingCartRepository
    {
        void AddProductToCart(ShoppingCartEntity cartItem);
        bool IsProductInSomeonesCart(string email, int id);
        bool IsProductInWholeCart(int id);
        void DeleteProductFromCart(int id);
        void EmptyCart();
        void UpdateProductInCart(int id, int quantity);
    }
}
