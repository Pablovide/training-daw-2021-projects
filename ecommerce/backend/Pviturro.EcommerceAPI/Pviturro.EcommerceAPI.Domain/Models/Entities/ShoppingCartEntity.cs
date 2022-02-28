using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Models.Entities
{
    public class ShoppingCartEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public ProductEntity Product { get; set; }
    }
}
