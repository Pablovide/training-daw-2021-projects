using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pviturro.EcommerceAPI.Domain.Models.DTOs
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public string ProductName => Product.Name;
        public decimal Price => Product.Price;
        public decimal Total => Product.Price * Quantity;


    }
}
