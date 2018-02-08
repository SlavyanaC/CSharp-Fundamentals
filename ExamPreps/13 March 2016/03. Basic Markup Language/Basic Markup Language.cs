using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _03._Basic_Markup_Language
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            var input = string.Empty;
            while ((input = Console.ReadLine().Trim()) != "<stop/>")
            {
                var tokens = input.Trim('<').Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                Regex pattern = new Regex(@"""([A-Za-z0-9]+)""");
                MatchCollection matches = pattern.Matches(input);

                string[] textArgs = input.Split(new[] { '"' }).ToArray();
                if (textArgs[1].Contains(' '))
                {
                    counter++;
                    Console.WriteLine($"{counter}.");
                    continue;
                }
                
                else if (matches.Count > 1)
                {
                    MatchCollection collection = pattern.Matches(input);
                    var matchRepeats = matches[0];
                    int repeats = int.Parse(matchRepeats.ToString().Trim('"'));
                    if (repeats == 0)
                    {
                        counter++;
                        Console.WriteLine($"{counter}.");
                        continue;
                    }
                    var message = matches[1];
                    var result = message.ToString().Trim('"');
                    for (int i = 0; i < repeats; i++)
                    {
                        counter++;
                        PrintOutput(counter, result);
                    }
                }

                else if (matches.Count == 1)
                {
                    var message = pattern.Match(input);
                    switch (command)
                    {
                        case "inverse":
                            counter++;
                            ExecuteInverseCommand(message, counter);
                            break;
                        case "reverse":
                            counter++;
                            ExecuteReverseCommand(message, counter);
                            break;
                    }
                }
            }
        }

        private static void ExecuteReverseCommand(Match message, int counter)
        {
            StringBuilder result = new StringBuilder();
            string mtch = message.Groups[1].Value;
            for (int i = mtch.Length - 1; i >= 0; i--)
            {
                result.Append(mtch[i]);
            }

            PrintOutput(counter, result.ToString());
        }

        private static void ExecuteInverseCommand(Match message, int counter)
        {
            StringBuilder result = new StringBuilder();
            foreach (var ch in message.Groups[1].Value)
            {
                if (char.IsUpper(ch))
                {
                    result.Append(char.ToLower(ch));
                }
                else if (char.IsLower(ch))
                {
                    result.Append(char.ToUpper(ch));
                }
                else
                {
                    result.Append(ch);
                }
            }

            PrintOutput(counter, result.ToString());
        }

        private static void PrintOutput(int counter, string result)
        {
            Console.WriteLine($"{counter}. {result}");
        }
    }
}
