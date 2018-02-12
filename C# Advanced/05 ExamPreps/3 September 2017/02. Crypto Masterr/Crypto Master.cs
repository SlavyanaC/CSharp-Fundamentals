using System;
using System.Linq;

namespace _02._Crypto_Masterr
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int bestSequence = 0;
            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step) % numbers.Length;
                    int currentSequence = 1;
                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % numbers.Length;
                        currentSequence++;
                    }
                    if (currentSequence > bestSequence)
                    {
                        bestSequence = currentSequence;
                    }
                }
            }

            Console.WriteLine(bestSequence);
        }
    }
}
