using System;
using System.Collections.Generic;

public class Box<T>
    where T : IComparable<T>
{
    private IList<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public void Add(T item) => this.items.Add(item);

    public int GetCountOfGreaterElements(T element)
    {
        var count = 0;
        foreach (var item in this.items)
        {
            if (element.CompareTo(item) < 0)
            {
                count++;
            }
        }

        return count;
    }
}
