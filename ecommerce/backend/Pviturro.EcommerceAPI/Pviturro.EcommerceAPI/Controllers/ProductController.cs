using Microsoft.AspNetCore.Mvc;
using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using Pviturro.EcommerceAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Controllers
{
    public class ProductController : Controller
    {
        private IEcommerceService _service;

        public ProductController(IEcommerceService service)
        {
            _service = service;
        }

        [HttpGet("/product")]
        public IActionResult GetProducts()
        {
            try
            {
                var result = _service.GetProducts();
                return Ok(result);
            } catch (Exception e)
            {
                return BadRequest();
            } 
        }

        [HttpGet("/product/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var result = _service.GetProductById(id);
                return Ok(result);
            } catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("/product/byCategory/{id}")]
        public IActionResult GetProductByCategoryId(int id)
        {
            try
            {
                var result = _service.GetProductsByCategoryId(id);
                return Ok(result);
            } catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("/product")]
        public IActionResult AddProduct([FromBody] Product productToAdd)
        {
            try
            {
                _service.AddProduct(productToAdd);
                return NoContent();
            } catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("/product/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product productToUpdate)
        {
            try
            {
                _service.UpdateProduct(id, productToUpdate);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _service.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
