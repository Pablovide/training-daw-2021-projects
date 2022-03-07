using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Controllers
{
    public class ShoppingCartController : Controller
    {
        [HttpPut("/cart/add")]
        public IActionResult AddProductToCart()
        {
            throw new NotImplementedException();
        }

        [HttpPut("/cart/delete")]
        public IActionResult DeleteProductFromCart()
        {
            throw new NotImplementedException();
        }

        [HttpPut("/cart/update")]
        public IActionResult UpdateProductInCart()
        {
            throw new NotImplementedException();
        }

        [HttpPut("/cart/empty")]
        public IActionResult EmptyCart()
        {
            throw new NotImplementedException();
        }
    }
}
