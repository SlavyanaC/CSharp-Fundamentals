
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Queue_Operations
{
    class Basic_Queue_Operations
    {
        static void Main(string[] args)
        {
            int[] operators = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int elementsToEnqueue = operators[0];
            int elementsToDequeue = operators[1];
            int element = operators[2];

            Queue<int> numbers = new Queue<int>(Console.ReadLine()
                                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse));
            for (int i = 0; i < elementsToDequeue; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbers.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}