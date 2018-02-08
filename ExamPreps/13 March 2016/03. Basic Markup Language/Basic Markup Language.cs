using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace BasicMarkupLanguage
{
    // Solved with help
    public class BasicMarkup
    {
        private static int lineIndex = 1;

        public static void Main()
        {
            string pattern = @"\s*<\s*([a-z]+)\s+(?:value\s*=\s*""\s*(\d+)\s*""\s+)?[a-z]+\s*=\s*""([^""]*)""\s*\/>\s*";
            Regex rgx = new Regex(pattern);

            string line = Console.ReadLine();
            while (line != "<stop/>")
            {
                Match match = rgx.Match(line);
                string tag = match.Groups[1].Value;
                switch (tag)
                {
                    case "inverse":
                        ProcessInverseTag(match.Groups[3].Value);
                        break;
                    case "reverse":
                        ProcessReverseTag(match.Groups[3].Value);
                        break;
                    case "repeat":
                        ProcessRepeatTag(match.Groups[3].Value, int.Parse(match.Groups[2].Value));
                        break;
                }

                line = Console.ReadLine();
            }
        }

        private static void ProcessInverseTag(string input)
        {
            if (input.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char ch in input)
                {
                    if (char.IsUpper(ch))
                    {
                        sb.Append(char.ToLower(ch));
                    }
                    else if (char.IsLower(ch))
                    {
                        sb.Append(char.ToUpper(ch));
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                Console.WriteLine($"{lineIndex++}. {sb}");
            }
        }

        private static void ProcessReverseTag(string input)
        {
            if (input.Length > 0)
            {
                Console.WriteLine($"{lineIndex++}. {string.Join(string.Empty, input.Reverse())}");
            }
        }

        private static void ProcessRepeatTag(string input, int repetitions)
        {
            if (repetitions > 0 && input.Length > 0)
            {
                for (int i = 0; i < repetitions; i++)
                {
                    Console.WriteLine($"{lineIndex++}. {input}");
                }
            }
        }
    }
}
