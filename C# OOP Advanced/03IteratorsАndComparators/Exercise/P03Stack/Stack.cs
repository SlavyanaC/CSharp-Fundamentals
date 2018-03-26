using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private IList<T> collection;

    public Stack()
    {
        this.collection = new List<T>();
    }

    public void Push(params T[] items)
    {
        foreach (var item in items)
        {
            this.collection.Add(item);
        }
    }

    public void Pop()
    {
        int lastIndex = this.collection.Count - 1;
        if (lastIndex < 0)
        {
            throw new InvalidOperationException("No elements");
        }

        this.collection.RemoveAt(lastIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        int lastIndex = this.collection.Count - 1;
        for (int i = lastIndex; i >= 0; i--)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
