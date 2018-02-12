using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string currentLine = Console.ReadLine();
                stringbuilder.Append(currentLine);
            }
            string cryptoLine = stringbuilder.ToString();
            Regex pattern = new Regex(@"\[(?<block>\D*)(?<numbers>\d{3,})*(\D*)\]|\{(?<block>\D*)(?<numbers>\d{3,})*(\D*)\}");
            MatchCollection matches = pattern.Matches(cryptoLine);
            StringBuilder result = new StringBuilder();
            foreach (Match match in matches)
            {
                string numbers = match.Groups["numbers"].ToString();
                if (numbers.Length % 3 == 0)
                {
                    List<int> numbersList = new List<int>();
                    for (int i = 0; i < numbers.Length; i += 3)
                    {
                        string currentNumAsString = $"{numbers[i]}{numbers[i + 1]}{numbers[i + 2]}";
                        int currentNum = int.Parse(currentNumAsString) - match.Length;
                        numbersList.Add(currentNum);
                    }

                    StringBuilder currentMessage = new StringBuilder();
                    foreach (var num in numbersList)
                    {
                        currentMessage.Append((char)num);
                    }
                    result.Append(currentMessage);
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}
