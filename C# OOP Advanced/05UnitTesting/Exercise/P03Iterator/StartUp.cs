namespace P03Iterator
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            ListIterator listIterator = null;

            var inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var args = inputLine.Split();
                var command = args[0];
                switch (command)
                {
                    case "Create":
                        listIterator = new ListIterator(args.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(listIterator.Print());
                        }
                        catch (InvalidOperationException ie)
                        {
                            Console.WriteLine(ie.Message);
                        }
                        break;
                }
            }
        }
    }
}
