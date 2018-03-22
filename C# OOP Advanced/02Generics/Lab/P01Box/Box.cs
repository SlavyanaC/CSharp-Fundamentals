using System.Collections.Generic;

public class Box<T>
{
    private List<T> itmes;

    public Box()
    {
        this.itmes = new List<T>();
    }

    public void Add(T item) => this.itmes.Add(item);

    public T Remove()
    {
        int index = this.itmes.Count - 1;
        var item = this.itmes[index];
        this.itmes.RemoveAt(index);

        return item;
    }

    public int Count => this.itmes.Count;
}
