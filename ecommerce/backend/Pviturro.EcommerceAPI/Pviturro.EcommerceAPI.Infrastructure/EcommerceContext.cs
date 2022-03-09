using Microsoft.EntityFrameworkCore;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using Pviturro.EcommerceAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Infrastructure
{
    public class EcommerceContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }

        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }
    }
}
