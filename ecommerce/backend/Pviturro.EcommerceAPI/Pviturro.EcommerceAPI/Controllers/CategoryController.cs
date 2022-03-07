using Microsoft.AspNetCore.Mvc;
using Pviturro.EcommerceAPI.Domain.DTOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Controllers
{
    public class CategoryController : Controller
    {
        
        [HttpGet("/category")]
        public IActionResult GetCategories()
        {
            throw new NotImplementedException();
        }

        [HttpGet("/category/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("/category")]
        public IActionResult AddCategory([FromBody] Category categoryToAdd)
        {
            throw new NotImplementedException();
        }

        [HttpPut("/category/{id}")]
        public IActionResult UpdateCategory(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("/category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
