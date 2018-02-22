using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random random = new Random();

    public string RandomString()
    {
        string result = null;
        if (this.Count > 0)
        {
            var randomIndex = random.Next(0, this.Count - 1);
            result = this[randomIndex];
            this.RemoveAt(randomIndex);
        }

        return result;
    }
}
