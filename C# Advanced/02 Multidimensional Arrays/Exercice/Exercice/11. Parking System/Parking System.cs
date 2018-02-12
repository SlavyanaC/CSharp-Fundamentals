using System;
using System.Linq;

namespace _11._Parking_System
{
    public class ParkingSystem
    {
        static bool[][] parking;
        static int rows;
        static int cols;

        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = dimensions[0];
            cols = dimensions[1];
            parking = new bool[rows][];
            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                int[] commandArgs = command.Split() .Select(int.Parse).ToArray();
                int entryRow = commandArgs[0];
                int targetRow = commandArgs[1];
                int targetCol = commandArgs[2];
                if (IsSpotTaken(targetRow, targetCol))
                {
                    targetCol = TryFindFreeSpot(targetRow, targetCol);
                }
                if (targetCol > 0)
                {
                    MatkSpotAsTaken(targetRow, targetCol);

                    int distancePassed = Math.Abs(entryRow - targetRow) + targetCol + 1;
                    Console.WriteLine(distancePassed);
                }
                else
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
            }
        }

        private static void MatkSpotAsTaken(int targetRow, int targetCol)
        {
            if (parking[targetRow] == null)
            {
                parking[targetRow] = new bool[cols];
            }
            parking[targetRow][targetCol] = true;
        }

        private static int TryFindFreeSpot(int targetRow, int targetCol)
        {
            int parkingCol = 0;
            int bestDistance = int.MaxValue;
            for (int currentCol = 1; currentCol < cols; currentCol++)
            {
                if (!parking[targetRow][currentCol])
                {
                    int distance = Math.Abs(currentCol - targetCol);
                    if (distance < bestDistance)
                    {
                        parkingCol = currentCol;
                        bestDistance = distance;
                    }
                }
            }

            return parkingCol;
        }

        private static bool IsSpotTaken(int targetRow, int targetCol)
        {
            return parking[targetRow] != null && parking[targetRow][targetCol];
        }
    }
}