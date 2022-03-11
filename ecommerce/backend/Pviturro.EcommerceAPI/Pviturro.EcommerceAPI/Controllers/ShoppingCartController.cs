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

        [HttpPut("/cart/add/")]
        public IActionResult AddProductToCart([FromBody] ShoppingCart cartItem)
        {
            try
            {
                _service.AddProductToCart(cartItem);
                return NoContent();
            } catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/cart/delete/{productid}")]
        public IActionResult DeleteProductFromCart(int productid)
        {
            try
            {
                _service.DeleteProductFromCart(productid);
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("/cart/update/{id}/{qtity}")]
        public IActionResult UpdateProductInCart(int id, int qtity, string email)
        {
            try
            {
                _service.UpdateProductInCart(id, qtity, email);
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest();
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
                return BadRequest();
            }
        }
    }
}
