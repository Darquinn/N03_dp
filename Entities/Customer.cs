using fastwebsite.IteratorPattern;
using System;
using System.Collections.Generic;

namespace fastwebsite.Entities;

public partial class Customer : IIterableCollection<Order>
{
    public int AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();


    //Prototype - Lân
    public Customer Clone()
    {
        return new Customer
        {
            AccountId = this.AccountId,
            Name = this.Name,
            Email = this.Email,
            Password = this.Password,
            Phone = this.Phone,
            Address = this.Address,

            // Sao chép từng phần tử trong danh sách (Deep Copy)
            Carts = this.Carts.Select(cart => new Cart
            {
                CartId = cart.CartId,
                AccountId = cart.AccountId,
                TotalPrice = cart.TotalPrice,
                CartItems = cart.CartItems.Select(item => new CartItem
                {
                    CartItemId = item.CartItemId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            }).ToList(),

            Orders = this.Orders.Select(order => new Order
            {
                OrderId = order.OrderId,
                AccountId = order.AccountId,
                TotalPrice = order.TotalPrice,
                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    OrderItemId = item.OrderItemId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            }).ToList(),

            Reviews = this.Reviews.Select(review => new Review
            {
                AccountId = review.AccountId,
                ProductId = review.ProductId,
                Rates = review.Rates,
                Content = review.Content
            }).ToList()
        };
    }

    //Iterator - Lân 
    public IIterator<Order> GetIterator()
    {
        return new OrderIterator(Orders.ToList());
    }
}
