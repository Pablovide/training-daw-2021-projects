using Pviturro.EcommerceAPI.Domain.MapFactories;
using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using Pviturro.EcommerceAPI.Domain.Repositories;
using Pviturro.EcommerceAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.ServiceLibrary.Services
{
    public class CategoryService : ICategoryService
    {
        private IEcommerceContext _context;
        public void AddCategory(Category categoryToAdd)
        {
            _context.CreateCategory(categoryToAdd.Map());
        }

        public void DeleteCategory(int id)
        {
            _context.DeleteCategory(id);
        }

        public List<Category> GetCategories()
        {
            return _context.GetAllCategories().Select(_ => _.Map()).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.GetCategoryById(id).Map();
        }

        public void UpdateCategory(int id, Category categoryUpdated)
        {
            _context.UpdateCategory(id, categoryUpdated.Map());
        }
    }
}
