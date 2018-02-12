using System;

namespace _08._Recursive_Fibonacci
{
    class Program
    {
        static long[] fibonacci;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            fibonacci = new long[n];
            fibonacci[0] = 1;
            if (n > 1)
            {
                fibonacci[1] = 1;
            }
            Console.WriteLine(getFibonacci(n - 1));
        }

        static long getFibonacci(int n)
        {
            if (fibonacci[n] == 0)
            {
                fibonacci[n] = getFibonacci(n - 1) + getFibonacci(n - 2);
            }
            return fibonacci[n];
        }
    }
}
