using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Parking_System
{
    public class ParkingSystem
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();

            string[] input = Console.ReadLine().Split().ToArray();
            while (!input[0].Equals("stop"))
            {
                int enter = int.Parse(input[0]);
                int wantedRow = int.Parse(input[1]);
                int wantedCol = int.Parse(input[2]);
                bool foundSpot = false;

                if (!IsOccupied(parking, wantedRow, wantedCol))
                {
                    foundSpot = true;
                    if (parking.ContainsKey(wantedRow))
                    {
                        parking[wantedRow].Add(wantedCol);
                    }
                    else
                    {
                        parking[wantedRow] = new HashSet<int>() { wantedCol };
                    }

                    int count = Math.Abs(enter - wantedRow) + 1 + wantedCol;
                    Console.WriteLine(count);
                }
                else
                {
                    for (int move = 0; move < cols; move++)
                    {
                        if (wantedCol - move > 0 && !IsOccupied(parking, wantedRow, wantedCol - move))
                        {
                            foundSpot = true;
                            parking[wantedRow].Add(wantedCol - move);
                            int count = Math.Abs(enter - wantedRow) + 1 + wantedCol - move;
                            Console.WriteLine(count);
                            break;
                        }
                        if (wantedCol + move < cols && !IsOccupied(parking, wantedRow, wantedCol + move))
                        {
                            foundSpot = true;
                            parking[wantedRow].Add(wantedCol + move);
                            int count = Math.Abs(enter - wantedRow) + 1 + wantedCol + move;
                            Console.WriteLine(count);
                            break;
                        }
                    }
                }

                if (!foundSpot)
                {
                    Console.WriteLine($"Row {wantedRow} full");
                }

                input = Console.ReadLine().Split().ToArray();
            }
        }

        public static bool IsOccupied(Dictionary<int, HashSet<int>> parking, int row, int col)
        {
            if (parking.ContainsKey(row))
            {
                if (parking[row].Contains(col))
                {
                    return true;
                }
            }
            return false;
        }
    }
}