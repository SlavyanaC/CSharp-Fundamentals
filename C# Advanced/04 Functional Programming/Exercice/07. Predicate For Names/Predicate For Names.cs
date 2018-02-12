using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            names = names.Where(name => LengthFilter(name, x => x <= length)).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }

        private static bool LengthFilter (string name, Func<int, bool> filter)
        {
            return filter(name.Length);
        }
    }
}
