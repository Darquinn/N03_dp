using fastwebsite.ObserverPattern;
using System;
using System.Collections.Generic;

namespace fastwebsite.Entities;

public partial class Order : ISubject<Order>
{
    public int OrderId { get; set; }
    public int? AccountId { get; set; }
    public decimal? TotalPrice { get; set; }
    public DateTime? OrderDate { get; set; }
    public string State { get; set; }
    public string? CodeCoupon { get; set; }
    public int? TypePaymentId { get; set; }

    public virtual Customer? Account { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual TypePayment? TypePayment { get; set; }

    public Order(int accountId, decimal totalPrice, string state, string? codeCoupon, int typePaymentId)
    {
        AccountId = accountId;
        TotalPrice = totalPrice;
        OrderDate = DateTime.Now;
        State = state;
        CodeCoupon = codeCoupon;
        TypePaymentId = typePaymentId;
    }

    public Order() { }


    //Observer - Lân 
    private readonly List<IOrderObserver> ob = new List<IOrderObserver>();

    public void Attach(IOrderObserver observer)
    {
        ob.Add(observer);
    }

    public void Detach(IOrderObserver observer)
    {
        ob.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in ob)
        {
            observer.Update(this);
        }
    }

    public void ChangeState(string newState)
    {
        State = newState;
        Console.WriteLine($"Đơn hàng {OrderId} thay đổi trạng thái thành: {State}");
        Notify();  
    }
}
