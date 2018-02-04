using System;
using System.Linq;

namespace _08_RadioActiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[matrixData[0], matrixData[1]];
            int[] playerPosition = new int[2];
            FillMatrix(matrix, playerPosition);
            string commands = Console.ReadLine();
            for (int i = 0; i < commands.Length; i++)
            {
                MovePlayer(commands[i], playerPosition);
                bool isWin = IsGameWon(matrix, playerPosition);
                char[,] mutatedMatrix = MutateBunnies(matrix);
                matrix = mutatedMatrix;
                if (isWin)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
                    Environment.Exit(0);
                }
                IsGameOver(matrix, playerPosition);
            }

            matrix[playerPosition[0], playerPosition[1]] = 'P';
            PrintMatrix(matrix);
            Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
        }

        private static bool IsGameWon(char[,] matrix, int[] playerPosition)
        {
            bool isGameWon = false;
            if (playerPosition[0] >= matrix.GetLength(0) || playerPosition[0] < 0 || 
                playerPosition[1] < 0 || playerPosition[1] >= matrix.GetLength(1))
            {
                isGameWon = true;
                if (playerPosition[0] >= matrix.GetLength(0))
                {
                    playerPosition[0] = matrix.GetLength(0) - 1;
                }
                else if (playerPosition[0] < 0)
                {
                    playerPosition[0] = 0;
                }
                else if (playerPosition[1] >= matrix.GetLength(1))
                {
                    playerPosition[1] = matrix.GetLength(1) - 1;
                }
                else if (playerPosition[1] < 0)
                {
                    playerPosition[1] = 0;
                }
            }

            return isGameWon;
        }

        private static void IsGameOver(char[,] matrix, int[] playerPosition)
        {
            if (matrix[playerPosition[0], playerPosition[1]] == 'B')
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
                Environment.Exit(0);
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] MutateBunnies(char[,] matrix)
        {
            int topBorder = 0;
            int bottomBorder = matrix.GetLength(0);

            int leftBorder = 0;
            int rightBorder = matrix.GetLength(1);

            char[,] mutatedMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
            FillBlankMutatedMatrix(mutatedMatrix);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        mutatedMatrix[row, col] = 'B';
                        if ((col + 1) < rightBorder && matrix[row, col + 1] == '.')
                        {
                            mutatedMatrix[row, col + 1] = 'B';
                        }
                        if ((col - 1) >= leftBorder && matrix[row, col - 1] == '.')
                        {
                            mutatedMatrix[row, col - 1] = 'B';
                        }
                        if ((row + 1) < bottomBorder && matrix[row + 1, col] == '.')
                        {
                            mutatedMatrix[row + 1, col] = 'B';
                        }
                        if ((row - 1) >= topBorder && matrix[row - 1, col] == '.')
                        {
                            mutatedMatrix[row - 1, col] = 'B';
                        }
                    }
                }
            }

            return mutatedMatrix;
        }

        private static void FillBlankMutatedMatrix(char[,] mutatedMatrix)
        {
            for (int row = 0; row < mutatedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < mutatedMatrix.GetLength(1); col++)
                {
                    mutatedMatrix[row, col] = '.';
                }
            }
        }

        private static void MovePlayer(char command, int[] playerPosition)
        {
            switch (command)
            {
                case 'R': playerPosition[1] += 1; break;
                case 'L': playerPosition[1] -= 1; break;
                case 'U': playerPosition[0] -= 1; break;
                case 'D': playerPosition[0] += 1; break;
            }
        }

        private static void FillMatrix(char[,] matrix, int[] playerStart)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                if (input.Contains('P'))
                {
                    playerStart[0] = row;
                    playerStart[1] = input.IndexOf('P');
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            matrix[playerStart[0], playerStart[1]] = '.';
        }
    }
}