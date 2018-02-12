using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var evenNums = sequence.FindAll(n => n % 2 == 0);
            evenNums.Sort();
            var oddNums = sequence.FindAll(n => n % 2 != 0);
            oddNums.Sort();
            Console.WriteLine(string.Join(" ", evenNums.Concat(oddNums)));
        }
    }
}
