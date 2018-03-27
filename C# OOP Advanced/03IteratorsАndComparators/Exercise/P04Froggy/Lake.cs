using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private IList<int> stones;

    public Lake(params int[] stones)
    {
        this.stones = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int index = 1; index <= this.stones.Count; index++)
        {
            if (index % 2 != 0)
            {
                yield return this.stones[index - 1];
            }
        }

        for (int index = this.stones.Count; index >= 1; index--)
        {
            if (index % 2 == 0)
            {
                yield return this.stones[index - 1];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
