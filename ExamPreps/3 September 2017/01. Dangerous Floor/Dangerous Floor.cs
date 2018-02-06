using System;

namespace _01._Dangerous_Floor
{
    // 75/100 
    class DangerousFloor

    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            board = InitializeBoard(board);
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                char piece = command[0];
                int takeRow = int.Parse(command[1].ToString());
                int takeCol = int.Parse(command[2].ToString());
                int moveRow = int.Parse(command[4].ToString());
                int moveCol = int.Parse(command[5].ToString());

                if (board[takeRow, takeCol] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                switch (piece)
                {
                    case 'K':
                        bool isValid = CheckIfKingMovementIsValid(takeRow, takeCol, moveRow, moveCol);
                        if (!isValid)
                        {
                            PrintInvalidMessage();
                        }
                        if (!StaysOnBoard(moveRow, moveCol, board))
                        {
                            continue;
                        }
                        break;
                    case 'R':
                        if (moveRow != takeRow && moveCol != takeCol)
                        {
                            PrintInvalidMessage();
                            continue;
                        }
                        if (!StaysOnBoard(moveRow, moveCol, board))
                        {
                            continue;
                        }
                        break;
                    case 'B':
                        if (Math.Abs(moveRow - takeRow) != Math.Abs(moveCol - takeCol))
                        {
                            PrintInvalidMessage();
                            continue;
                        }
                        if (!StaysOnBoard(moveRow, moveCol, board))
                        {
                            continue;
                        }
                        break;
                    case 'Q':
                        if ((moveRow != takeRow && moveCol != takeCol) && 
                            (Math.Abs(moveRow - takeRow) != Math.Abs(moveCol - takeCol)))
                        {
                            PrintInvalidMessage();
                            continue;
                        }
                        if (!StaysOnBoard(moveRow, moveCol, board))
                        {
                            continue;
                        }
                        break;
                    case 'P':
                        if (moveRow != takeRow - 1 || moveCol != takeCol)
                        {
                            PrintInvalidMessage();
                            continue;
                        }
                        if (!StaysOnBoard(moveRow, moveCol, board))
                        {
                            continue;
                        }
                        break;
                }
                board = RearrangeBoard(piece, takeRow, takeCol, moveRow, moveCol, board);
            }
        }

        private static void PrintBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (col == board.GetLength(1) - 1)
                    {
                        Console.Write(board[row, col]);
                    }
                    else
                    {
                        Console.Write(board[row, col] + ",");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PrintInvalidMessage()
        {
            Console.WriteLine("Invalid move!");
        }

        private static char[,] RearrangeBoard(char piece, int takeRow, int takeCol, int moveRow, int moveCol, char[,] board)
        {
            board[takeRow, takeCol] = 'x';
            board[moveRow, moveCol] = piece;

            return board;
        }

        private static bool CheckIfKingMovementIsValid(int takeRow, int takeCol, int moveRow, int moveCol)
        {
           return (moveRow == takeRow - 1 && moveCol == takeCol) || // upLeft
                  (moveRow == takeRow && moveCol == takeCol - 1) || // left
                  (moveRow == takeRow + 1 && moveCol == takeCol - 1) || //dowLeft
                  (moveRow == takeRow - 1 && moveCol == takeCol) || // up
                  (moveRow == takeRow + 1 && moveCol == takeCol) || // down
                  (moveRow == takeRow - 1 && moveCol == takeCol + 1) || // upRight
                  (moveRow == takeRow && moveCol == takeCol + 1) || // right
                  (moveRow == takeRow + 1 && moveCol == takeCol + 1); //downRight
        }

        private static bool StaysOnBoard(int moveRow, int moveCol, char[,] board)
        {
            if (moveRow < 0 || moveRow > 7 || moveCol < 0 || moveCol > 7)
            {
                Console.WriteLine("Move go out of board!");
                return false;
            }

            return true;
        }

        private static char[,] InitializeBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < board.GetLength(1); col++)
                    board[row, col] = char.Parse(line[col]);
            }
            return board;
        }
    }
}
