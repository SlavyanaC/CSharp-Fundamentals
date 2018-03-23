public class Threeuple<TFirst, TSecond, TThird>
{
    public TFirst First { get;  set; }

    public TSecond Second { get;  set; }

    public TThird Third { get;  set; }

    public override string ToString()
    {
        var result = $"{this.First} -> {this.Second} -> {this.Third}";
        return result;
    }
}
