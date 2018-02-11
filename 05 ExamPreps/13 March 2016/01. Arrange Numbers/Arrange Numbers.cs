using System;
using System.Linq;

namespace ArrangeIntegers
{
    public class ArrangeIntegersMain
    {
        private static string[] IntNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(str => string.Join(string.Empty, str.Select(ch => IntNames[ch - '0'])))));
        }
    }
}
