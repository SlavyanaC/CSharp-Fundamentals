using System;
using System.Collections.Generic;
using System.Text;

public class StackOfStrings
{
    List<string> data = new List<string>();

    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    public void Push(string newElement)
    {
        data.Add(newElement);
    }

    public string Peek()
    {
        string result = string.Empty;
        if (!IsEmpty())
        {
            result = data[data.Count - 1];
        }

        return result;
    }

    public string Pop()
    {
        string result = string.Empty;
        if (!IsEmpty())
        {
            var lastIndex = data.Count - 1;
            result =  data[lastIndex];
            data.RemoveAt(lastIndex);
        }

        return result;
    }
}
