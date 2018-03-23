public class Tuple<Tfirst, Tsecond>
{
    private Tfirst firstItem;
    private Tsecond secondItem;

    public Tuple(Tfirst firstItem, Tsecond secondItem)
    {
        this.firstItem = firstItem;
        this.secondItem = secondItem;
    }

    public override string ToString()
    {
        var result = $"{this.firstItem} -> {this.secondItem}";
        return result;
    }
}
