using Microsoft.AspNetCore.Mvc;
using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("/product")]
        public IActionResult GetProducts()
        {
            throw new NotImplementedException();
        }

        [HttpGet("/product/{id}")]
        public IActionResult GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/product/byCategory/{id}")]
        public IActionResult GetProductByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("/product")]
        public IActionResult AddProduct([FromBody] Product productToAdd)
        {
            throw new NotImplementedException();
        }

        [HttpPut("/product/{id}")]
        public IActionResult UpdateProduct(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("/product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
