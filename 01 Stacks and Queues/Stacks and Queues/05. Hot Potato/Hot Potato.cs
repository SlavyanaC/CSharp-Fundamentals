using System;
using System.Collections.Generic;

namespace _05._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split(' ');
            var num = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(children);
            while(queue.Count != 1)
            {
                for (int i = 1; i < num; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
