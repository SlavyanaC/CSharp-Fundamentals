using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> appendSir = name => Console.WriteLine($"Sir {name}");
            foreach (var name in Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries))
            {
                appendSir(name);             
            }
        }
    }
}
