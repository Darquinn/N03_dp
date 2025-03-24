using fastwebsite.MediatorPattern;
using System;
using System.Collections.Generic;

namespace fastwebsite.Entities;

//Mediator - Lân 
public partial class Cart
{
    private IMediator? _mediator;

    public int CartId { get; set; }
    public int? AccountId { get; set; }
    public decimal? TotalPrice { get; set; }
    public virtual Customer? Account { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void AddCartItem(CartItem item)
    {
        CartItems.Add(item);
        _mediator?.Notify(item, "CartItemUpdated");
    }

    public void RemoveCartItem(CartItem item)
    {
        CartItems.Remove(item);
        _mediator?.Notify(item, "CartItemUpdated");
    }
}

