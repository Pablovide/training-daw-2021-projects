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
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private DbSet<ShoppingCartEntity> _shoppingCart;

        public ShoppingCartRepository(EcommerceContext context)
        {
            _shoppingCart = context.ShoppingCarts;
        }

        public void AddProductToCart(ShoppingCartEntity cartItem)
        {
            _shoppingCart.Add(new ShoppingCartEntity { Email = cartItem.Email, Product = cartItem.Product, Quantity = cartItem.Quantity });
        }

        public void DeleteProductFromCart(int id)
        {
            _shoppingCart.RemoveRange(_shoppingCart.Where(_ => _.Product.Id == id).ToList());
        }

        public void EmptyCart()
        {
            _shoppingCart.RemoveRange(_shoppingCart.ToList());
        }

        public bool IsProductInSomeonesCart(string email, int id)
        {
            return _shoppingCart.Any(_ => _.Product.Id == id && _.Email.Equals(email));
        }

        public bool IsProductInWholeCart(int id)
        {
            return _shoppingCart.Any(_ => _.Product.Id == id);
        }

        public void UpdateProductInCart(int id, int quantity)
        {
            var order = _shoppingCart.Where(_ => _.Product.Id == id).Single();
            order.Quantity = quantity;
        }
    }
}
