﻿using Microsoft.EntityFrameworkCore;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using Pviturro.EcommerceAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private DbSet<CategoryEntity> _categories;

        public CategoryRepository(IEcommerceContext context)
        {
            _categories = context.Categories;
        }



    }
}
