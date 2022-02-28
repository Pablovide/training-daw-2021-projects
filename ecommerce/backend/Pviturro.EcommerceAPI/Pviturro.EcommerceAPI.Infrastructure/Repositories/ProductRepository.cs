using Microsoft.EntityFrameworkCore;
using Pviturro.EcommerceAPI.Domain.Infrastructure;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using Pviturro.EcommerceAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DbSet<ProductEntity> _products;

        public ProductRepository(IEcommerceContext context)
        {
            _products = context.Products;
        }
    }
}
