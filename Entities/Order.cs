using System;
using System.Collections.Generic;

namespace fastwebsite.Entities;

public partial class Order
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
        State = state;  // Giữ trạng thái dưới dạng chuỗi
        CodeCoupon = codeCoupon;
        TypePaymentId = typePaymentId;
    }
    public Order() { }
}
