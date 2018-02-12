using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bound = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = bound[0];
            int end = bound[1];

            string command = Console.ReadLine();
            Predicate<int> predicate = CheckIfEvenOrOdd;

            for (int i = start; i <= end; i++)
            {
                if (command == "even" && predicate(i))
                {
                    Console.Write(i + " ");
                }
                else if (command == "odd" && !predicate(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        private static bool CheckIfEvenOrOdd(int num)
        {
            return num % 2 == 0;
        }
    }
}
