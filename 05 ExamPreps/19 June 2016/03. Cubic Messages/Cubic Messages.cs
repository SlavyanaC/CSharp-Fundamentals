using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = string.Empty;
            while ((inputText = Console.ReadLine()) != "Over!")
            {
                int m = int.Parse(Console.ReadLine());
                Regex pattern = new Regex($"^(\\d+)([A-Za-z]{{{m}}})([^A-Za-z]*)$");
                Match match = pattern.Match(inputText);

                if (pattern.IsMatch(inputText))
                {
                    var firstDigits = match.Groups[1].Value;
                    var message = match.Groups[2].Value;
                    var secondDigits = match.Groups[3].Value;

                    List<int> indices = new List<int>();
                    foreach (var item in firstDigits)
                    {
                        indices.Add((int)item - 48);
                    }
                    foreach (var item in secondDigits)
                    {
                        indices.Add((int)item - 48);
                    }

                    StringBuilder output = new StringBuilder();
                    output.Append(message);
                    output.Append(" == ");
                    foreach (var index in indices)
                    {
                        if (index >= 0 && index < message.Length)
                        {
                            output.Append(message[index]);
                        }
                        else
                        {
                            output.Append(" ");
                        }
                    }

                    Console.WriteLine(output.ToString());
                }
            }
        }
    }
}
