namespace fastwebsite.IteratorPattern
{
    public interface IIterableCollection<T>
    {
        IIterator<T> GetIterator();
    }

}
