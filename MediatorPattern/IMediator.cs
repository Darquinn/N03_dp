namespace fastwebsite.MediatorPattern
{
    public interface IMediator
    {
        void Notify(object sender, string eventType, object? data = null);
    }
}
