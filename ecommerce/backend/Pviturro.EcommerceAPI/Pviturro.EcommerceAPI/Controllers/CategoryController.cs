using Microsoft.AspNetCore.Mvc;
using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using Pviturro.EcommerceAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Controllers
{
    public class CategoryController : Controller
    {
        private IEcommerceService _service;

        public CategoryController(IEcommerceService service)
        {
            _service = service;
        }

        [HttpGet("/category")]
        public IActionResult GetCategories()
        {
            try
            {
                var result = _service.GetCategories();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/category/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var result = _service.GetCategoryById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/category")]
        public IActionResult AddCategory([FromBody] Category categoryToAdd)
        {
            try
            {
                _service.AddCategory(categoryToAdd);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/category/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category categoryUpdated)
        {
            try
            {
                _service.UpdateCategory(id, categoryUpdated);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _service.DeleteCategory(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
