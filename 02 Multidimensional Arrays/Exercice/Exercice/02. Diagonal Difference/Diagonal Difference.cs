using System;
using System.Linq;

namespace _02._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                var rowItems = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowItems[col];
                }
            }
            long primerySum = 0;
            for (int row = 0; row < n; row++)
            {
                primerySum += matrix[row, row];
            }

            long secondarySum = 0;
            for (int row = 0, col = n - 1; row < n; row++, col--)
            {
                secondarySum += matrix[row, col];
            }
            Console.WriteLine(Math.Abs(primerySum - secondarySum));
        }
    }
}
