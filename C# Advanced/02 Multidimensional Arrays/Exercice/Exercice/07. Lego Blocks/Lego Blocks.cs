using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var countRows = int.Parse(Console.ReadLine());
            var firstJagged = new int[countRows][];
            var secondJagged = new int[countRows][];

            FillJaggedArr(firstJagged);
            FillJaggedArr(secondJagged);

            bool canFit = CheckIfCanFit(firstJagged, secondJagged);
            if (canFit == false)
            {
                int countCells = CalculateCellsCount(firstJagged, secondJagged);
                Console.WriteLine($"The total number of cells is: {countCells}");
            }
            else
            {
                var reversedSecond = new List<List<int>>(ReverseSecondJagged(secondJagged));
                List<List<int>> result = new List<List<int>>(GetResultJagged(firstJagged, reversedSecond));
                PrintResult(result);
            }
        }

        private static void PrintResult(List<List<int>> result)
        {
            foreach (var line in result)
            {
                Console.Write("[");
                for (int i = 0; i < line.Count; i++)
                {
                    if (i != line.Count - 1)
                    {
                        Console.Write(line[i] + ", ");
                    }
                    else
                    {
                        Console.Write(line[i]);
                    }
                }

                Console.WriteLine("]");
            }
        }

        private static List<List<int>> GetResultJagged(int[][] firstJagged, List<List<int>> reversedSecond)
        {
            List<List<int>> result = new List<List<int>>();
            for (int row = 0; row < firstJagged.GetLength(0); row++)
            {
                List<int> line = new List<int>();
                for (int col = 0; col < firstJagged[row].Length + reversedSecond[row].Count; col++)
                {
                    if (col < firstJagged[row].Length)
                    {
                        line.Add(firstJagged[row][col]);
                    }
                    else
                    {
                        for (int col2 = 0; col2 < reversedSecond[row].Count; col2++)
                        {
                            line.Add(reversedSecond[row][col2]);
                        }
                        break;
                    }
                }
                result.Add(line);
            }
            return result;
        }

        private static List<List<int>> ReverseSecondJagged(int[][] jagged)
        {
            var reversedList = new List<List<int>>();
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                List<int> line = new List<int>();
                for (int col = jagged[row].Length - 1; col >= 0; col--)
                {
                    var itemToAdd = jagged[row][col];
                    line.Add(itemToAdd);
                }
                reversedList.Add(line);
            }

            return reversedList;
        }

        private static int CalculateCellsCount(int[][] firstJagged, int[][] secondJagged)
        {
            var sum = 0;
            for (int row = 0; row < firstJagged.Length; row++)
            {
                for (int col = 0; col < firstJagged[row].Length; col++)
                {
                    sum++;
                }
            }

            for (int row = 0; row < secondJagged.Length; row++)
            {
                for (int col = 0; col < secondJagged[row].Length; col++)
                {
                    sum++;
                }
            }

            return sum;
        }

        private static bool CheckIfCanFit(int[][] firstJagged, int[][] secondJagged)
        {
            int longestLine = 0;
            for (int f = 0, s = 0; f < firstJagged.Length; f++, s++)
            {
                int firstJaggedLine = firstJagged[f].Length;
                int secondJaggedLine = secondJagged[s].Length;
                if (firstJaggedLine + secondJaggedLine > longestLine)
                {
                    longestLine = firstJaggedLine + secondJaggedLine;
                }
            }

            for (int currentRow = 0; currentRow < firstJagged.GetLength(0); currentRow++)
            {
                if (firstJagged[currentRow].Length + secondJagged[currentRow].Length == longestLine)
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        private static int[][] FillJaggedArr(int[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                int[] lineValues = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged[row] = new int[lineValues.Length];
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = lineValues[col];
                }
            }

            return jagged;
        }
    }
}
