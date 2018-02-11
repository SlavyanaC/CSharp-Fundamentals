using System;
using System.Linq;
using System.Text;

namespace _02._Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int r = input[0];
            int c = input[1];
            char[,] board = new char[r, c];
            board = InitializeBoard(board);

            int money = 50;

            bool hasBoughtHotel = false;
            int countHotels = 0;

            int turnsCount = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (row % 2 == 0) // move right
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        switch (board[row, col])
                        {
                            case 'H':
                                countHotels++;
                                PrintHotelOutput(money, countHotels);
                                turnsCount++;
                                money = 0;
                                hasBoughtHotel = true;
                                if (hasBoughtHotel)
                                {
                                    money += countHotels * 10;
                                }
                                break;
                            case 'J':
                                PrintJailOutput(turnsCount);
                                turnsCount++;
                                turnsCount += 2;
                                if (hasBoughtHotel)
                                {
                                    money += 3 * (countHotels * 10);
                                }
                                break;
                            case 'S':
                                turnsCount++;
                                if (hasBoughtHotel)
                                {
                                    money += countHotels * 10;
                                }
                                var moneySpent = (row + 1) * (col + 1);
                                if (money <= moneySpent)
                                {
                                    moneySpent = money;
                                }
                                money -= moneySpent;
                                PrintHotelOutput(moneySpent);
                                break;
                            default:
                                turnsCount++;
                                if (hasBoughtHotel)
                                {
                                    money += countHotels * 10;
                                }
                                break;
                        }
                    }
                }
                else // move left
                {
                    for (int col = board.GetLength(1) - 1; col >= 0; col--) 
                    {
                        switch (board[row, col])
                        {
                            case 'H':
                                countHotels++;
                                PrintHotelOutput(money, countHotels);
                                turnsCount++;
                                money = 0;
                                hasBoughtHotel = true;
                                if (hasBoughtHotel)
                                {
                                    money += countHotels * 10;
                                }
                                break;
                            case 'J':
                                PrintJailOutput(turnsCount);
                                turnsCount++;
                                turnsCount += 2;
                                if (hasBoughtHotel)
                                {
                                    money += 3 * (countHotels * 10);
                                }
                                break;
                            case 'S':
                                turnsCount++;
                                if (hasBoughtHotel)
                                {
                                    money += countHotels * 10;
                                }
                                var moneySpent = (row + 1) * (col + 1);
                                if (money <= moneySpent)
                                {
                                    moneySpent = money;
                                }
                                money -= moneySpent;
                                PrintHotelOutput(moneySpent);
                                break;
                            default:
                                turnsCount++;
                                if (hasBoughtHotel)
                                {
                                    money += countHotels * 10;
                                }
                                break;
                        }
                    }
                }
            }

            Console.WriteLine($"Turns {turnsCount}");
            Console.WriteLine($"Money {money}");
        }

        private static void PrintJailOutput(int turnsCount)
        {
            Console.WriteLine($"Gone to jail at turn {turnsCount}.");
        }

        private static void PrintHotelOutput(int moneySpent)
        {
            Console.WriteLine($"Spent {moneySpent} money at the shop.");
        }

        private static void PrintHotelOutput(int money, int countHotels)
        {
            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {countHotels}.");
        }

        private static char[,] InitializeBoard(char[,] board)
        {
            var result = board;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    result[row, col] = currentRow[col];
                }
            }

            return result;
        }
    }
}
