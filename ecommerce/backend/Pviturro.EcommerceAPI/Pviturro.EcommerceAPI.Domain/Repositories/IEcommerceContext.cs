using Microsoft.EntityFrameworkCore;
using Pviturro.EcommerceAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Repositories
{
    public interface IEcommerceContext
    {
        DbSet<CategoryEntity> Categories { get; set; }
        DbSet<ProductEntity> Products { get; set; }
        DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }
    }
}
