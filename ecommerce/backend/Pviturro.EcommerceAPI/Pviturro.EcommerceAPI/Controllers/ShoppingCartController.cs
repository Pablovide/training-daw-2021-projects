using Microsoft.AspNetCore.Mvc;
using Pviturro.EcommerceAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IEcommerceService _service;

        public ShoppingCartController(IEcommerceService service)
        {
            _service = service;
        }

        [HttpPut("/cart/add/{id}")]
        public IActionResult AddProductToCart(int id)
        {
            try
            {
                _service.AddProductToCart(id);
                return NoContent();
            } catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("/cart/delete/{id}")]
        public IActionResult DeleteProductFromCart(int id)
        {
            try
            {
                _service.DeleteProductFromCart(id);
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("/cart/update/{id}/{qtity}")]
        public IActionResult UpdateProductInCart(int id, int qtity)
        {
            try
            {
                _service.UpdateProductInCart(id, qtity);
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("/cart/empty")]
        public IActionResult EmptyCart()
        {
            try
            {
                _service.EmptyCart();
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
