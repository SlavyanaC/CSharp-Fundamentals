using System;
using System.Text;

namespace P06_Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            InitializeMatrix(n, matrix);

            char[] commands = Console.ReadLine().ToCharArray();
            int[] samPosition = new int[2];
            FindSam(matrix, samPosition);

            for (int i = 0; i < commands.Length; i++)
            {
                MoveEnemies(matrix);

                int[] getEnemy = new int[2];
                FindEnemy(matrix, samPosition, getEnemy);

                if (samPosition[1] < getEnemy[1] && matrix[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
                {
                    matrix[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    PrintMatrix(matrix);
                    Environment.Exit(0);
                }
                else if (getEnemy[1] < samPosition[1] && matrix[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
                {
                    matrix[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    PrintMatrix(matrix);
                    Environment.Exit(0);
                }

                char command = commands[i];
                matrix[samPosition[0]][samPosition[1]] = '.';
                switch (command)
                {
                    case 'U':
                        samPosition[0]--;
                        break;
                    case 'D':
                        samPosition[0]++;
                        break;
                    case 'L':
                        samPosition[1]--;
                        break;
                    case 'R':
                        samPosition[1]++;
                        break;
                    default:
                        break;
                }
                matrix[samPosition[0]][samPosition[1]] = 'S';

                FindEnemy(matrix, samPosition, getEnemy);

                if (matrix[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    matrix[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintMatrix(matrix);
                    Environment.Exit(0);
                }
            }
        }

        private static void FindEnemy(char[][] matrix, int[] samPosition, int[] getEnemy)
        {
            for (int j = 0; j < matrix[samPosition[0]].Length; j++)
            {
                if (matrix[samPosition[0]][j] != '.' && matrix[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                    break;
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    sb.Append(matrix[row][col]);
                }

                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }

        private static void MoveEnemies(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void FindSam(char[][] room, int[] samPosition)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                        break;
                    }
                }
            }
        }

        private static void InitializeMatrix(int n, char[][] room)
        {
            for (int row = 0; row < n; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}