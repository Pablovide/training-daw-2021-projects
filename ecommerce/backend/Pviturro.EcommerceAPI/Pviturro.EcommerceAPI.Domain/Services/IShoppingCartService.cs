using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Services
{
    public interface IShoppingCartService
    {
        void AddProductToCart(int id);
        bool ContainsProduct(int id);
        void DeleteProductFromCart(int id);
        void EmptyCart();
        void UpdateProductInCart(int id, int quantity);
    }
}
