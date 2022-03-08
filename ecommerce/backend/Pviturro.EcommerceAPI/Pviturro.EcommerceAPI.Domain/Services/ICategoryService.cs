using Pviturro.EcommerceAPI.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category categoryToAdd);
        Category GetCategoryById(int id);
        void DeleteCategory(int id);
        List<Category> GetCategories();
        void UpdateCategory(int id, Category categoryUpdated);
    }
}
