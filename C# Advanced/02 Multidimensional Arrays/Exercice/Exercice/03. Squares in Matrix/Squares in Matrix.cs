using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int row = 0; row < input[0]; row++)
            {
                var rowItems = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = rowItems[col];
                }
            }
            int countSquares = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentItem = matrix[row, col];
                    var rightItem = matrix[row, col + 1];
                    var bottomItem = matrix[row + 1, col];
                    var diagonalItem = matrix[row + 1, col + 1];
                    if (currentItem.Equals(rightItem)
                        && currentItem.Equals(bottomItem)
                        && currentItem.Equals(diagonalItem)
                        && rightItem.Equals(bottomItem)
                        && rightItem.Equals(diagonalItem)
                        && bottomItem.Equals(diagonalItem))
                    {
                        countSquares++;
                    }
                }
            }

            Console.WriteLine(countSquares);
        }
    }
}