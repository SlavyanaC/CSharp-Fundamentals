using System;
using System.Collections.Generic;

namespace P07CustomList
{
    class StartUp
    {
        static void Main()
        {
            var input = string.Empty;
            CustomList<string> customList = new CustomList<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();
                ExecuteCommand(customList, args);
            }
        }

        private static void ExecuteCommand(CustomList<string> customList, string[] args)
        {
            var command = args[0];
            switch (command)
            {
                case "Add":
                    customList.Add(args[1]);
                    break;
                case "Remove":
                    var index = int.Parse(args[1]);
                    customList.Remove(index);
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(args[1]));
                    break;
                case "Swap":
                    var firstIndex = int.Parse(args[1]);
                    var secondIndex = int.Parse(args[2]);
                    customList.Swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    Console.WriteLine(customList.GetCountOfGreaterElements(args[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Sort":
                    customList.Sort();
                    break;
                case "Print":
                    Console.WriteLine(customList);
                    break;
            }
        }
    }
}
