using System;

namespace P02GenericBoxOfInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var box = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }
        }
    }
}
