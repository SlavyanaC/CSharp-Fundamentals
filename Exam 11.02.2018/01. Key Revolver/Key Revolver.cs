using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolver
{
    class Program
    {
        static long priceBullets;
        static long barrelSize;
        static long valueIntelligence;
        static Stack<long> bullets;
        static Queue<long> locks;

        static void Main(string[] args)
        {
            priceBullets = long.Parse(Console.ReadLine());
            barrelSize = long.Parse(Console.ReadLine());
            bullets = new Stack<long>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse));
            locks = new Queue<long>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse));
            valueIntelligence = long.Parse(Console.ReadLine());

            long initialBarelSize = barrelSize;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                ShootLock(initialBarelSize);
            }
        }

        private static void ShootLock(long initialBarelSize)
        {
            long bullet = bullets.Pop();
            if (bullet <= locks.Peek())
            {
                locks.Dequeue();
                Console.WriteLine("Bang!");
                barrelSize--;
                valueIntelligence -= priceBullets;
            }
            else
            {
                Console.WriteLine("Ping!");
                barrelSize--;
                valueIntelligence -= priceBullets;
            }

            if (barrelSize == 0)
            {
                barrelSize = initialBarelSize;
                if (bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueIntelligence}");
                }
                else if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                }
            }
            else
            {
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueIntelligence}");
                }
                else if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                }
            }
        }
    }
}
