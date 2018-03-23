public class Box<T>
{
    private T item;

    public Box(T item)
    {
        this.item = item;
    }


    public override string ToString()
    {
        var result = $"{this.item.GetType().FullName}: {item}";
        return result;
    }
}
