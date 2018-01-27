using System;
using System.Collections.Generic;

namespace _03._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputDecimal = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            if (inputDecimal == 0)
            {
                Console.Write(0);
            }
            while (inputDecimal > 0)
            {
                stack.Push(inputDecimal % 2);
                inputDecimal /= 2;

            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
