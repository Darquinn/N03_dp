using fastwebsite.Entities;

namespace fastwebsite.IteratorPattern
{
    public class OrderIterator : IIterator<Order>
    {
        private List<Order> _orders;
        private int _position = 0;

        public OrderIterator(List<Order> orders)
        {
            this._orders = orders ?? new List<Order>();
        }

        public bool HasNext()
        {
            return _position < _orders.Count;
        }

        public Order Next()
        {
            return HasNext() ? _orders[_position++] : null;
        }
    }

}
