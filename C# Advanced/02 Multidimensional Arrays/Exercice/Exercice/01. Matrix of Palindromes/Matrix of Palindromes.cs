using System;
using System.Linq;

namespace _01._Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = rowAndCol[0];
            var cols = rowAndCol[1];
            string[,] palidromMatrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var matrixItem = string.Empty;
                for (int col = 0; col < cols; col++)
                {
                    palidromMatrix[row, col] = $"{(char)('a' + row)}{(char)('a' + row + col)}{(char)('a' + row)}";  
                }
            }

            for (int row = 0; row < palidromMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < palidromMatrix.GetLength(1); col++)
                {
                    Console.Write(palidromMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
