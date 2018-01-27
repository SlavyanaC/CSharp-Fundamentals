using System;
using System.Collections.Generic;
using System.Text;

namespace _10._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var undoCommands = new Stack<string>();
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                string[] command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "1":
                        undoCommands.Push(text.ToString());
                        text.Append(command[1]);
                        break;
                    case "2":
                        undoCommands.Push(text.ToString());
                        var textt = text.ToString();
                        text.Clear();
                        text.Append(textt.Substring(0, textt.Length - int.Parse(command[1])));
                        break;
                    case "3":
                        var wantedElement = text.ToString()[int.Parse(command[1]) - 1];
                        Console.WriteLine(wantedElement);
                        break;
                    case "4":
                        var previosPosition = undoCommands.Pop();
                        text.Clear();
                        text.Append(previosPosition);
                        break;
                }
            }

        }
    }
}
