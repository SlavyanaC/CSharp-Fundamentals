using System;

public class Scale<T>
    where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHeavier()
    {
        var comparedItems = this.left.CompareTo(right);
        if (comparedItems > 0)
            return left;

        if (comparedItems < 0)
            return right;

        return default(T);
    }
}
