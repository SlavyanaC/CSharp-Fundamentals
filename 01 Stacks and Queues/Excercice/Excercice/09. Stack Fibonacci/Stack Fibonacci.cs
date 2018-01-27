using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stackFibonacci = new Stack<long>();
            stackFibonacci.Push(1);
            stackFibonacci.Push(1);
            for (int i = 2; i < n; i++)
            {
                long first = stackFibonacci.Pop();
                var second = stackFibonacci.Peek() + first;
                stackFibonacci.Push(first);
                stackFibonacci.Push(second);
            }
            Console.WriteLine(stackFibonacci.Pop());
        }
    }
}
