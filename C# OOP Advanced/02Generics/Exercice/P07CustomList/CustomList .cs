using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
    where T : IComparable<T>
{
    private IList<T> items;

    public CustomList()
    {
        this.items = new List<T>();
    }

    public void Add(T item) => this.items.Add(item);

    public T Remove(int index)
    {
        var item = this.items[index];
        this.items.RemoveAt(index);
        return item;
    }

    public bool Contains(T item) => this.items.Contains(item);

    public void Swap(int firstindex, int secondIndex)
    {
        var firstElement = this.items[firstindex];
        this.items[firstindex] = this.items[secondIndex];
        this.items[secondIndex] = firstElement;
    }

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

    public T Max()
    {
        var element = this.items.First();
        foreach (var item in this.items)
        {
            if (item.CompareTo(element) > 0)
            {
                element = item;
            }
        }

        return element;
    }

    public T Min()
    {
        var element = this.items.First();
        foreach (var item in this.items)
        {
            if (item.CompareTo(element) < 0)
            {
                element = item;
            }
        }

        return element;
    }


    public override string ToString()
    {
        var builder = new StringBuilder();
        foreach (var item in this.items)
        {
            builder.AppendLine($"{item}");
        }
        return builder.ToString().TrimEnd();
    }
}
