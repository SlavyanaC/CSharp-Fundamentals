using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var days = new int[n];
            var indexes = new Stack<int>();
            indexes.Push(0);
            for (int i = 0; i < plants.Length; i++)
            {
                int maxDays = 0;
                while (indexes.Count > 00 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);
                }
                if (indexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                indexes.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}
