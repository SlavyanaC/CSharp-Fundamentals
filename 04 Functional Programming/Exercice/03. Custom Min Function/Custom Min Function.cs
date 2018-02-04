using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<IEnumerable<int>, int> min = FindMinValue;
            List<int> sequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(min(sequence));
        }

        private static int FindMinValue(IEnumerable<int> sequence)
        {
            int minValue = int.MaxValue;
            foreach (var num in sequence)
            {
                if (num < minValue)
                {
                    minValue = num;
                }
            }

            return minValue;
        }
    }
}
