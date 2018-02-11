using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sneaking
{
    class Sneaking
    {
        static char[][] board;
        static int rows;
        static int columns;

        static int samsRow;
        static int samsCol;

        static int nicksRow;
        static int nicksCol;
        static List<char> moves;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            rows = n;
            board = new char[n][];
            InitializeBoard();
            moves = Console.ReadLine().ToList();
            while (moves.Count > 0)
            {
                int enemyRow;
                int enemyCol;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        if (board[row][col] == 'b' || board[row][col] == 'd')
                        {
                            enemyRow = row;
                            enemyCol = col;
                            if (board[row][col] == 'b')
                            {
                                MarkBNewSpots(enemyRow, enemyCol);
                            }
                            else
                            {
                                MarkDNewSpots(enemyRow, enemyCol);
                            }
                        }
                    }
                }

                MoveEnemies();
                bool isOnSamsRow = CheckIfOnTheSameRow();
                bool isFacingSam = CheckIfEnemyIsFacingSam();
                if (isOnSamsRow && isFacingSam)
                {
                    board[samsRow][samsCol] = 'X';
                    Console.WriteLine($"Sam died at {samsRow}, {samsCol}");
                    PrintBoard();
                    return;
                }
                MoveSam(moves[0]);
                if (samsRow == nicksRow)
                {
                    board[nicksRow][nicksCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintBoard();
                    return;
                }
            }
        }

        private static void MoveSam(char move)
        {
            board[samsRow][samsCol] = '.';
            switch (move)
            {
                case 'U':
                    samsRow = samsRow - 1;
                    break;
                case 'D':
                    samsRow = samsRow + 1;
                    break;
                case 'L':
                    samsCol = samsCol - 1;
                    break;
                case 'R':
                    samsCol = samsCol + 1;
                    break;
            }
            board[samsRow][samsCol] = 'S';
            moves.RemoveAt(0);
        }

        private static bool CheckIfEnemyIsFacingSam()
        {
            int enemyCol = 0;
            if (board[samsRow].Contains('b'))
            {
                for (int col = 0; col < board[samsRow].Length; col++)
                {
                    if (board[samsRow][col] == 'b')
                    {
                        enemyCol = col;
                    }
                }

                if (samsCol > enemyCol)
                {
                    return true;
                }
            }

            else if (board[samsRow].Contains('d'))
            {
                for (int col = 0; col < board[samsRow].Length; col++)
                {
                    if (board[samsRow][col] == 'd')
                    {
                        enemyCol = col;
                    }
                }

                if (samsCol < enemyCol)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckIfOnTheSameRow()
        {
            return board[samsRow].Contains('b') || board[samsRow].Contains('d');
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (board[row][col] == 'q')
                    {
                        board[row][col] = 'd';
                    }
                    else if (board[row][col] == 'p')
                    {
                        board[row][col] = 'b';
                    }
                }
            }
        }

        private static void MarkDNewSpots(int enemyRow, int enemyCol) // Mark with d
        {
            if (enemyCol == 0)
            {
                board[enemyRow][enemyCol] = 'p';
            }
            else
            {
                board[enemyRow][enemyCol] = '.';
                enemyCol -= 1;
                board[enemyRow][enemyCol] = 'q';
            }
        }

        private static void MarkBNewSpots(int enemyRow, int enemyCol) // Mark wit p
        {
            if (enemyCol == columns - 1)
            {
                board[enemyRow][enemyCol] = 'q';
            }
            else
            {
                board[enemyRow][enemyCol] = '.';
                enemyCol += 1;
                board[enemyRow][enemyCol] = 'p';
            }
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(board[row]);
            }
        }

        private static void InitializeBoard()
        {
            for (int row = 0; row < rows; row++)
            {
                string inputLine = Console.ReadLine();
                columns = inputLine.Length;
                board[row] = inputLine.ToArray();
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (board[row][col] == 'S')
                    {
                        samsRow = row;
                        samsCol = col;
                    }
                    if (board[row][col] == 'N')
                    {
                        nicksRow = row;
                        nicksCol = col;
                    }
                }
            }
        }
    }
}
