using System;
using System.Linq;

namespace _03._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] varieties = new int[3];
            foreach (var num in numbers)
            {
                varieties[Math.Abs(num % 3)]++;
            }

            int[][] solution = new int[3][];
            for (int counter = 0; counter < varieties.Length; counter++)
            {
                solution[counter] = new int[varieties[counter]];
            }

            int[] index = new int[3];
            foreach (var num in numbers)
            {
                var reminder = Math.Abs(num % 3);
                solution[reminder][index[reminder]] = num;
                index[reminder]++;
            }

            for (int row = 0; row < solution.Length; row++)
            {
                for (int col = 0; col < solution[row].Length; col++)
                {
                    Console.Write(solution[row][col] + " ");
                }
                Console.WriteLine();
            }
             Console.WriteLine();
        }
    }
}
