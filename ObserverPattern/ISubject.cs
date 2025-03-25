namespace fastwebsite.ObserverPattern
{
    public interface ISubject<T>
    {
        void Attach(IOrderObserver observer);  
        void Detach(IOrderObserver observer);
        void Notify();  
    }
}
