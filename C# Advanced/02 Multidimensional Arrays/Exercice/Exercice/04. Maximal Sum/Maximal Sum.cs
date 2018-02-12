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
                var rowItems = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = rowItems[col];
                }
            }
            int bestSum = 0;
            int rowIndex = 0;
            int colIndex = 0;
            int[,] solutionMatrix = new int[3, 3];
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    //firs row
                    var currentItem = matrix[row, col];
                    var firstRowSecond = matrix[row, col + 1];
                    var firstRowLast = matrix[row, col + 2];

                    //second row
                    var secondRowFirst = matrix[row +1 , col];
                    var secondRowSecond = matrix[row + 1, col + 1];
                    var secondRowLast = matrix[row + 1, col + 2];

                    //Third row
                    var thirdRowFirst = matrix[row + 2, col];
                    var thirdRowSecond = matrix[row + 2, col + 1];
                    var thirdRowLast = matrix[row + 2, col + 2];


                    var currentSum = currentItem + firstRowSecond + firstRowLast +
                        secondRowFirst + secondRowSecond + secondRowLast +
                        thirdRowFirst + thirdRowSecond + thirdRowLast;

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            //firs row
            var currentItem1 = matrix[rowIndex, colIndex];
            var firstRowSecond1 = matrix[rowIndex, colIndex + 1];
            var firstRowLast1 = matrix[rowIndex, colIndex + 2];

            //second row
            var secondRowFirst1 = matrix[rowIndex + 1, colIndex];
            var secondRowSecond1 = matrix[rowIndex + 1, colIndex + 1];
            var secondRowLast1 = matrix[rowIndex + 1, colIndex + 2];

            //Third row
            var thirdRowFirst1 = matrix[rowIndex + 2, colIndex];
            var thirdRowSecond1 = matrix[rowIndex + 2, colIndex + 1];
            var thirdRowLast1 = matrix[rowIndex + 2, colIndex + 2];

            Console.WriteLine($"Sum = {bestSum}");
            Console.WriteLine($"{currentItem1} {firstRowSecond1} {firstRowLast1}");
            Console.WriteLine($"{secondRowFirst1} {secondRowSecond1} {secondRowLast1}");
            Console.WriteLine($"{thirdRowFirst1} {thirdRowSecond1} {thirdRowLast1}");
        }
    }
}