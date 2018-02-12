using System;
using System.Linq;

namespace _09._Crossfire
{
    class Crossfire
    {
        public static void Main()
        {
            var matrix = InitializeMatrix();
            matrix = ExecuteCommands(matrix);
            PrintAliveCells(matrix);
        }

        private static void PrintAliveCells(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row].Where(e => e != -1)));
            }
        }

        private static int[][] ExecuteCommands(int[][] matrix)
        {
            var command = Console.ReadLine().Trim();
            while (command != "Nuke it from orbit")
            {
                var commandDetails = command.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var shotRow = commandDetails[0];
                var shotCol = commandDetails[1];
                var radius = commandDetails[2];
                matrix = ShootMatrix(matrix, shotRow, shotCol, radius);

                command = Console.ReadLine().Trim();
            }

            return matrix;
        }

        private static int[][] ShootMatrix(int[][] matrix, int shotRow, int shotCol, int radius)
        {
            for (int col = shotCol - radius; col <= shotCol + radius; col++) // ROWS
            {
                if (IsInMatrix(shotRow, col, matrix))
                {
                    matrix[shotRow][col] = -1;
                }
            }

            for (int row = shotRow - radius; row <= shotRow + radius; row++) // COLS
            {
                if (IsInMatrix(row, shotCol, matrix))
                {
                    matrix[row][shotCol] = -1;
                }
            }
          
            for (int row = 0; row < matrix.Length; row++)  // REMOVE CELLS
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] < 0)
                    {
                        matrix[row] = matrix[row].Where(n => n > 0).ToArray();
                        break;
                    }
                }

                if (matrix[row].Length < 1) // REMOVE EMPY ROWS
                {
                    matrix = matrix.Take(row).Concat(matrix.Skip(row + 1)).ToArray();
                    row--;
                }
            }

            return matrix;
        }

        private static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            if (row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }

        private static int[][] InitializeMatrix()
        {
            var dimensions = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var element = 1;
            var matrix = new int[dimensions[0]][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[dimensions[1]];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = element;
                    element++;
                }
            }

            return matrix;
        }
    }
}
