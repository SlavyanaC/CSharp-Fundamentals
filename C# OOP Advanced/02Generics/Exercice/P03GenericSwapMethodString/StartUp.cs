using System;
using System.Linq;

namespace P03GenericSwapMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var box = new Box<string>();
            for (int i = 0; i < count; i++)
            {
                box.Add(Console.ReadLine());
            }

            var indices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(indices[0], indices[1]);
            Console.WriteLine(box.ToString());
        }
    }
}
