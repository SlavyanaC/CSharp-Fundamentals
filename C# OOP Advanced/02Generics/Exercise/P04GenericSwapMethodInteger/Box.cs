using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public void Add(T item) => this.items.Add(item);

    public void Swap(int firstindex, int secondIndex)
    {
        var firstElement = this.items[firstindex];
        this.items[firstindex] = this.items[secondIndex];
        this.items[secondIndex] = firstElement;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        foreach (var item in this.items)
        {
            builder.AppendLine($"{item.GetType().FullName}: {item}");
        }
        return builder.ToString().TrimEnd();
    }
}
