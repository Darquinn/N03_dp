using fastwebsite.Entities;

namespace fastwebsite.MediatorPattern
{
    public class CartMediator : IMediator
    {
        private readonly Cart _cart;

        public CartMediator(Cart cart)
        {
            _cart = cart;
        }

        public void Notify(object sender, string eventType, object? data = null)
        {
            if (sender is CartItem cartItem)
            {
                if (eventType == "CartItemUpdated")
                {
                    UpdateTotalPrice();
                }
            }
        }

        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in _cart.CartItems)
            {
                total += (item.Price ?? 0) * (item.Quantity ?? 1);
            }
            _cart.TotalPrice = total;
            Console.WriteLine($"🔄 Tổng giá giỏ hàng được cập nhật: {total:C}");
        }
    }

}
