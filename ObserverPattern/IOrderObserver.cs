using fastwebsite.Entities;

namespace fastwebsite.ObserverPattern
{
    public interface IOrderObserver
    {
        void Update(Order order);
    }

}
