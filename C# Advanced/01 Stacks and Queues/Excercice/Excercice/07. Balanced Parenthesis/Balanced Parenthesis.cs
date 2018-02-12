using System;
using System.Collections.Generic;

namespace _07._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var paranthesesStack = new Stack<char>();
            var paratheses = new Dictionary<char, char>();
            paratheses.Add('(', ')');
            paratheses.Add('[', ']');
            paratheses.Add('{', '}');
            bool isBalanced = true;
            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }
            foreach (var element in input)
            {
                if (paratheses.ContainsKey(element))
                {
                    paranthesesStack.Push(element);
                }
                else if (paranthesesStack.Count == 0 || element != paratheses[paranthesesStack.Peek()])
                {
                    isBalanced = false;
                    break;
                }
                else if (element == paratheses[paranthesesStack.Peek()])
                {
                    paranthesesStack.Pop();
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
}
