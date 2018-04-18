using System;

public class ConsoleWriter : IOutputWriter
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}