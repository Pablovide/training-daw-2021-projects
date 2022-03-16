using Microsoft.AspNetCore.Mvc;
using Pviturro.EcommerceAPI.Domain.Models.DTOs;
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

        [HttpPost("/cart/add/")]
        public IActionResult AddProductToCart([FromBody] ShoppingCart cartItem)
        {
            try
            {
                _service.AddProductToCart(cartItem);
                return NoContent();
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/cart/delete/{productid}")]
        public IActionResult DeleteProductFromCart(int productid, string email)
        {
            try
            {
                _service.DeleteProductFromCart(productid, email);
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/cart/update/{productId}/{qtity}")]
        public IActionResult UpdateProductInCart(int productId, int qtity, string email)
        {
            try
            {
                _service.UpdateProductInCart(productId, qtity, email);
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/cart/empty")]
        public IActionResult EmptyCart()
        {
            try
            {
                _service.EmptyCart();
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
