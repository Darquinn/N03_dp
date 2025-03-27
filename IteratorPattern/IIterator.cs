﻿namespace fastwebsite.IteratorPattern
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

}
