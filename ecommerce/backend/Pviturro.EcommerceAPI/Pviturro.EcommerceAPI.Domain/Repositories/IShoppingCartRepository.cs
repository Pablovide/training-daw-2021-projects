using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Repositories
{
    public interface IShoppingCartRepository
    {
        void AddProductToCart(int id, Models.Entities.ProductEntity product);
        bool IsProductInCart(int id);
        void DeleteProductFromCart(int id);
        void EmptyCart();
        void UpdateProductInCart(int id, int quantity);
    }
}
