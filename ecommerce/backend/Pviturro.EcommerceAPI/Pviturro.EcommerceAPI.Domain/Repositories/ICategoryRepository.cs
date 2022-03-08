using Pviturro.EcommerceAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Infrastructure
{
    public interface ICategoryRepository
    {
        void CreateCategory(CategoryEntity categoryEntity);
        void DeleteCategory(int id);
        List<CategoryEntity> GetAllCategories();
        CategoryEntity GetCategoryById(int id);
        void UpdateCategory(int id, CategoryEntity categoryEntity);
    }
}
