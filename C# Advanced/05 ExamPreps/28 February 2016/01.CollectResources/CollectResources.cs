using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CollectResources
{
    class CollectResources
    {
        static List<string> validResources = new List<string> { "stone", "gold", "wood", "food" };
        static string[] resourceField;
        static bool[] visitedCells;

        static void Main(string[] args)
        {
            resourceField = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int pathsCount = int.Parse(Console.ReadLine());
            int bestQuantity = int.MinValue;
            for (int i = 0; i < pathsCount; i++)
            {
                visitedCells = new bool[resourceField.Length];
                int[] paht = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int start = paht[0];
                int step = paht[1];

                int currentQuantity = GetQuentity(start);
                int currentIndex = (start + step) % resourceField.Length;
                while (!visitedCells[currentIndex])
                {
                    currentQuantity += GetQuentity(currentIndex);
                    currentIndex = (currentIndex + step) % resourceField.Length;
                }

                if (currentQuantity > bestQuantity)
                {
                    bestQuantity = currentQuantity;
                }
            }

            Console.WriteLine(bestQuantity);
        }

        private static int GetQuentity(int currentIndex)
        {
            string[] resourceTokens = resourceField[currentIndex].Split('_').ToArray();
            string resource = resourceTokens[0];
            if (validResources.Contains(resource))
            {
                visitedCells[currentIndex] = true;
                if (resourceTokens.Length > 1)
                {
                    return int.Parse(resourceTokens[1]);
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
