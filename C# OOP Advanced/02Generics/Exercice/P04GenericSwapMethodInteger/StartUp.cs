using System;
using System.Linq;

namespace P04GenericSwapMethodInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var box = new Box<int>();
            for (int i = 0; i < count; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }

            var indices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(indices[0], indices[1]);
            Console.WriteLine(box.ToString());
        }
    }
}
