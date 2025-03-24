using fastwebsite.Entities;

namespace fastwebsite.Factory
{
    //hsdihihda
    public abstract class OrderFactory
    {
        public abstract Order CreateOrder(int accountId, decimal totalPrice, string codeCoupon, int typePaymentId);
    }

    public class OrderFactoryImpl : OrderFactory
    {
        private readonly string _state;

        public OrderFactoryImpl(string state)
        {
            _state = state;
        }

        public override Order CreateOrder(int accountId, decimal totalPrice, string codeCoupon, int typePaymentId)
        {
            return new Order(accountId, totalPrice, _state, codeCoupon, typePaymentId);
        }
    }
}
