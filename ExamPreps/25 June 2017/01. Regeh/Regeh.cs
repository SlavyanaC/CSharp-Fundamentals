using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Regeh
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Regex regex = new Regex(@"\[{0}\S\w+(\<(\d+)REGEH(\d+)\>)\w+\]");
            MatchCollection matches = regex.Matches(input);
            var indices = new List<int>();
            foreach (Match match in matches)
            {
                var firstNums = int.Parse(match.Groups[2].Value);
                var secondNums = int.Parse(match.Groups[3].Value);

                indices.Add(firstNums);
                indices.Add(secondNums);
            }

            StringBuilder result = new StringBuilder();
            var index = 0;
            foreach (var i in indices)
            {
                index += i;
                int currIndex = index % input.Length;
                result.Append(input[currIndex]);
            }
            Console.WriteLine(result.ToString());
        }
    }
}
