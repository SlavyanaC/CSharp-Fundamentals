using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= end; i++)
            {
                numbers.Add(i);
            }
            for (int i = 0; i < dividers.Count; i++)
            {
                numbers = numbers.Where(n => n % dividers[i] == 0).ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
