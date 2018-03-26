using System;
using System.Linq;

public class Interpreter
{
    private Stack<string> stack;

    public Interpreter()
    {
        this.stack = new Stack<string>();
    }

    internal void Run()
    {
        string inputLine = string.Empty;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var args = inputLine.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var command = args[0];
            switch (command)
            {
                case "Push":
                    this.stack.Push(args.Skip(1).ToArray());
                    break;
                case "Pop":
                    try
                    {
                        this.stack.Pop();
                    }
                    catch (InvalidOperationException oe)
                    {
                        Console.WriteLine(oe.Message);
                        return;
                    }
                    break;
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, this.stack));
        Console.WriteLine(string.Join(Environment.NewLine, this.stack));
    }
}