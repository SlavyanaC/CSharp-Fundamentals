using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private IList<T> collection;
    private int currentIndex;

    public ListyIterator(IList<T> collection)
    {
        this.collection = collection;
        this.Reset();
    }

    public bool Move()
    {
        bool hasMoved = ++currentIndex < this.collection.Count;
        if (!hasMoved)
        {
            this.currentIndex--;
        }

        return hasMoved;
    }

    public bool HasNext()
    {
       return this.currentIndex + 1 < this.collection.Count;
    }

    private void Reset()
    {
        this.currentIndex = 0;
    }

    public T Print()
    {
        if (this.collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        T result = this.collection[currentIndex];
        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i++)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
