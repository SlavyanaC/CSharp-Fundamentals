using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int> add = num => num + 1; 
            Func<int, int> multiply = num => num * 2; 
            Func<int, int> subtract = num => num - 1;
            Action<IEnumerable<int>> print = seq => Console.WriteLine(string.Join(" ", seq));
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                switch (command)
                {
                    case "add":
                        sequence = sequence.Select(add).ToList();
                        break;
                    case "multiply":
                        sequence = sequence.Select(multiply).ToList();
                        break;
                    case "subtract":
                        sequence = sequence.Select(subtract).ToList();
                        break;
                    case "print":
                        print(sequence);
                        break;
                }
            }
        }
    }
}
