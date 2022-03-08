﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("/category")]
        public IActionResult GetCategories()
        {
            try
            {
                var result = _service.GetCategories();
                return Ok(result);
            } catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("/category/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var result = _service.GetCategoryById(id);
                return Ok(result);
            } catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("/category")]
        public IActionResult AddCategory([FromBody] Category categoryToAdd)
        {
            try
            {
                _service.AddCategory(categoryToAdd);
                return NoContent();
            } catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("/category/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category categoryUpdated)
        {
            try
            {
                _service.UpdateCategory(id, categoryUpdated);
                return NoContent();
            } catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _service.DeleteCategory(id);
                return NoContent();
            } catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
