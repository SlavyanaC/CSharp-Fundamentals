using System;
using System.Linq;

namespace _08_RadioActiveBunnies
{
    class Program
    {
        static char[,] board;
        static int playerRow;
        static int playerCol;
        static int rows;
        static int columns;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            board = ReadAndFillMatrix(dimensions);
            char[] movements = Console.ReadLine().ToCharArray();
            foreach (var move in movements)
            {
                int[] previousLocation = MovePlayer(move);
                MultiplyBunnies();

                if (IsPlayerOnBoard())
                {
                    if (board[playerRow, playerCol] == 'B')
                    {
                        Die();
                    }
                    continue;
                }

                Win(previousLocation);
            }
        }

        private static void Win(int[] previousLocation)
        {
            PrintBoard();

            int row = previousLocation[0];
            int col = previousLocation[1];
            Console.WriteLine($"won: {row} {col}");
            Environment.Exit(0);
        }

        private static void Die()
        {
            PrintBoard();

            Console.WriteLine($"dead: {playerRow} {playerCol}");
            Environment.Exit(0);
        }

        private static bool IsPlayerOnBoard()
        {
            return playerRow >= 0 && playerRow < rows &&
                   playerCol >= 0 && playerCol < columns;
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MultiplyBunnies()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (board[row, col] == 'B')
                    {
                        if (row > 0)
                        {
                            CreateNewBunny(row - 1, col); // Up
                        }
                        if (row < rows - 1)
                        {
                            CreateNewBunny(row + 1, col); // Down
                        }
                        if (col > 0)
                        {
                            CreateNewBunny(row, col - 1); // Left
                        }
                        if (col < columns - 1)
                        {
                            CreateNewBunny(row, col + 1); // Right
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (board[row, col] == 'X')
                    {
                        board[row, col] = 'B';
                    }
                }
            }
        }

        private static void CreateNewBunny(int row, int col)
        {
            if (board[row, col] != 'B')
            {
                board[row, col] = 'X';
            }
        }

        private static int[] MovePlayer(char move)
        {
            int[] previousLocation = { playerRow, playerCol };
            switch (move)
            {
                case 'U':
                    playerRow--;
                    break;
                case 'D':
                    playerRow++;
                    break;
                case 'L':
                    playerCol--;
                    break;
                case 'R':
                    playerCol++;
                    break;
            }

            if (IsPlayerOnBoard() && board[playerRow, playerCol] != 'B') // Move Player on board
            {
                board[playerRow, playerCol] = 'P';
            }

            int oldRow = previousLocation[0];
            int oldCol = previousLocation[1];

            board[oldRow, oldCol] = '.';

            return previousLocation;
        }

        private static char[,] ReadAndFillMatrix(int[] dimensions)
        {
            rows = dimensions[0];
            columns = dimensions[1];
            char[,] matrix = new char[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                var inputLine = Console.ReadLine();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = inputLine[col];
                    if (inputLine[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            return matrix;
        }
    }
}