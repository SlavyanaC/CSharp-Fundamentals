using System;
using System.Linq;

namespace _02.Cubic_s_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[,,] cube = new long[n, n, n];

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "Analyze")
            {
                var tokens = command.Split().Select(long.Parse).ToArray();
                long polongRow = tokens[0];
                long polongCol = tokens[1];
                long polongDiag = tokens[2];
                long particles = tokens[3];

                bool isIn = CheckIfPolongIsIn(polongRow, polongCol, polongDiag, cube);
                if (isIn)
                {
                    cube[polongRow, polongCol, polongDiag] += particles;
                }
            }

            PrlongOutput(cube);
        }

        private static void PrlongOutput(long[,,] cube)
        {
            long sumCells = 0;
            long notHitCellsCount = 0;
            for (long row = 0; row < cube.GetLength(0); row++)
            {
                for (long col = 0; col < cube.GetLength(1); col++)
                {
                    for (long diag = 0; diag < cube.GetLength(2); diag++)
                    {
                        if (cube[row, col, diag] != 0)
                        {
                            sumCells += cube[row, col, diag];
                        }
                        else
                        {
                            notHitCellsCount++;
                        }
                    }
                }
            }

            Console.WriteLine(sumCells);
            Console.WriteLine(notHitCellsCount);
        }

        private static bool CheckIfPolongIsIn(long polongRow, long polongCol, long polongDiag, long[,,] cube)
        {
            return (polongRow >= 0 && polongRow < cube.GetLength(0) && 
                    polongCol >= 0 && polongCol < cube.GetLength(1) && 
                    polongDiag >=0 && polongDiag < cube.GetLength(2));
        }
    }
}
