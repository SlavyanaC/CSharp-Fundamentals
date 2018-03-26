using System;
using System.Linq;

public class Interpreter
{
    ListyIterator<string> collection;

    public void Run()
    {
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split();
            var command = args[0];
            switch (command)
            {
                case "Create":
                    var elements = args.Skip(1).ToList();
                    if (elements.Count == 0)
                    {
                        Console.WriteLine($"Invalid Operation!");
                        return;
                    }
                    this.collection = new ListyIterator<string>(args.Skip(1).ToList());
                    break;

                case "Move":
                    Console.WriteLine(collection.Move());
                    break;

                case "HasNext":
                    Console.WriteLine(collection.HasNext());
                    break;

                case "Print":
                    try
                    {
                        Console.WriteLine(collection.Print());
                    }
                    catch (InvalidOperationException ie)
                    {
                        Console.WriteLine(ie.Message);
                    }
                    break;

                case "PrintAll":
                        Console.WriteLine(string.Join(" ", this.collection));
                    break;
            }
        }
    }
}
