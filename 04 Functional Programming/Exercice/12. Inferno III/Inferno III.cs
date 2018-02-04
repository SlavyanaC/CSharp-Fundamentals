using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var filters = new Dictionary<string, Func<List<int>, List<int>>>();

            string commandInput;
            while ((commandInput = Console.ReadLine()) != "Forge")
            {
                ParseCommand(commandInput, filters);
            }

            List<int> filtered = GetFiltered(gems, filters);
            gems = gems.Where(gem => !filtered.Contains(gem)).ToList();
            string result = string.Join(" ", gems);
            Console.WriteLine(result);
        }

        private static List<int> GetFiltered(List<int> gems, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            List<int> filtered = new List<int>();
            foreach (var pair in filters)
            {
                var filter = pair.Value;
                filtered.AddRange(pair.Value(gems));
            }

            return filtered;
        }

        private static void ParseCommand(string commandInput, Dictionary<string, Func<List<int>, List<int>>> filters)
        {
            string[] tokens = commandInput.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            string filterType = tokens[1];
            int parameter = int.Parse(tokens[2]);
            string dictKey = $"{filterType} {parameter}";

            if (command == "Exclude")
            {
                filters[dictKey] = CreateFunction(filterType, parameter);
            }
            else if (command == "Reverse")
            {
                filters.Remove(dictKey);
            }
        }

        private static Func<List<int>, List<int>> CreateFunction(string filterType, int parameter)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftGem = index > 0 ? gems[index - 1] : 0;
                        return gem + leftGem == parameter;
                    }).ToList();
                case "Sum Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return gem + rightGem == parameter;
                    }).ToList();
                case "Sum Left Right":
                    return gems => gems.Where(gem =>
                    {
                        int index = gems.IndexOf(gem);
                        int leftGem = index > 0 ? gems[index - 1] : 0;
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return leftGem + gem + rightGem == parameter;
                    }).ToList();
                default:
                    throw new ArgumentException("Не стана, брат");
            }
        }
    }
}
