using System;

public class ConsoleReader : IOutputReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}