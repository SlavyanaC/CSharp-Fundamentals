using System;
using System.Collections.Generic;

namespace _06._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPerLight = int.Parse(Console.ReadLine());
            var carsQueue = new Queue<string>();
            int carsPassedCount = 0;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                    break;

                if (input == "green")
                {
                    for (int i = 1; i <= carsPerLight; i++)
                    {
                        if (carsQueue.Count > 0)
                        {
                            var firstCar = carsQueue.Peek();
                            Console.WriteLine($"{firstCar} passed!");
                            carsQueue.Dequeue();
                            carsPassedCount++;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
            }
            Console.WriteLine($"{carsPassedCount} cars passed the crossroads.");
        }
    }
}