using System;

namespace _02._Knight_Game
{
    class KnightGame

    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];
            board = FillBoard(board);

            var minDeletes = 0;
            while (CheckIfCellIsAttacked(board))
            {
                minDeletes++;
            }
            Console.WriteLine(minDeletes);
        }

        private static bool CheckIfCellIsAttacked(char[,] board)
        {
            int maxEnemies = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int currentEnemies = 0;
                    if (board[row, col] == 'K')
                    {
                        currentEnemies = CalculateEnemies(row, col, board);
                        if (currentEnemies > maxEnemies)
                        {
                            maxEnemies = currentEnemies;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
            }

            if (maxEnemies > 0)
            {
                board[maxRow, maxCol] = '0';
                return true;
            }
            return false;
        }

        private static int CalculateEnemies(int row, int col, char[,] board)
        {
            int count = 0;

            var rightUp = row - 1 >= 0 && col + 2 < board.GetLength(1) ? board[row - 1, col + 2] : '0';
            var rightDown = row + 1 < board.GetLength(0) && col + 2 < board.GetLength(1) ? board[row + 1, col + 2] : '0';

            var leftUp = row - 1 >= 0 && col - 2 >= 0 ? board[row - 1, col - 2] : '0';
            var leftDown = row + 1 < board.GetLength(0) && col - 2 >= 0 ? board[row + 1, col - 2] : '0';

            var upRight = row - 2 >= 0 && col + 1 < board.GetLength(1) ? board[row - 2, col + 1] : '0';
            var upLeft = row - 2 >= 0 && col - 1 >= 0 ? board[row - 2, col - 1] : '0';

            var downRight = row + 2 < board.GetLength(0) && col + 1 < board.GetLength(1) ? board[row + 2, col + 1] : '0';
            var downLeft = row + 2 < board.GetLength(0) && col - 1 >= 0 ? board[row + 2, col - 1] : '0';

            if (rightUp == 'K') count++;
            if (rightDown == 'K') count++;
            if (leftUp == 'K') count++;
            if (leftDown == 'K') count++;
            if (upRight == 'K') count++;
            if (upLeft == 'K') count++;
            if (downRight == 'K') count++;
            if (downLeft == 'K') count++;

            return count;
        }

        private static char[,] FillBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = line[col];
                }
            }

            return board;
        }
    }
}