using Microsoft.EntityFrameworkCore;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using Pviturro.EcommerceAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DbSet<CategoryEntity> _categories;

        public CategoryRepository(EcommerceContext context)
        {
            _categories = context.Categories;
        }

        public void CreateCategory(CategoryEntity categoryEntity)
        {
            categoryEntity.Id = 0;
            _categories.Add(categoryEntity);
        }

        public void DeleteCategory(int id)
        {
            var category = _categories.Find(id);
            if(category != null)
            {
                _categories.Remove(category);
                return;
            }
            throw new Exception($"No se ha encontrado categoría con ID {id}");
        }

        public List<CategoryEntity> GetAllCategories()
        {
            return _categories.ToList();
        }

        public CategoryEntity GetCategoryById(int id)
        {
            var result = _categories.Find(id);
            if(result != null)
            {
                return result;
            }
            throw new Exception($"No se ha encontrado categoría con ID {id}");
        }

        public void UpdateCategory(int id, CategoryEntity categoryEntity)
        {
            var targetCategory = _categories.Find(id);
            if(targetCategory != null)
            {
                targetCategory.Description = categoryEntity.Description;
                targetCategory.Name = categoryEntity.Name;
                targetCategory.Products = categoryEntity.Products;
                return;
            }
            throw new Exception($"No se ha encontrado categoría con ID {id}");
        }
    }
}
