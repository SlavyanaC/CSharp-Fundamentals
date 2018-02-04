using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printNames = name => Console.WriteLine(name);
            foreach (var name in Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToList())
            {
                printNames(name);
            }
        }
    }
}
