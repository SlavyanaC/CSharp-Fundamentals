using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pumps = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }
            bool canMakeIt = false;
            for (int i = 0; i < n; i++)
            {
                long sum = 0;
                foreach (var pump in pumps)
                {
                    var pumpArr = pump.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();
                    int fuel = pumpArr[0];
                    int distance = pumpArr[1];
                    sum += fuel;
                    sum -= distance;
                    if (sum < 0)
                    {
                        canMakeIt = false;
                        break;
                    }
                    else
                    {
                        canMakeIt = true;
                    }
                }
                if (canMakeIt)
                {
                    Console.WriteLine(i);
                    return;
                }
                string helper = pumps.Dequeue();
                pumps.Enqueue(helper);
            }
        }
    }
}
