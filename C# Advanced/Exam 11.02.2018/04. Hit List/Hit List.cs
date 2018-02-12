using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hit_List
{
    class Program
    {
        static long targetInfoIndex;

        static void Main(string[] args)
        {
            targetInfoIndex = int.Parse(Console.ReadLine());
            var peopleWithInformation = new Dictionary<string, SortedDictionary<string, string>>();
            string peopleData = string.Empty;
            while ((peopleData = Console.ReadLine()) != "end transmissions")
            {
                var tokens = peopleData.Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = tokens[0];
                for (int i = 1; i < tokens.Length; i++)
                {
                    string[] infoAndValue = tokens[i].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string info = infoAndValue[0];
                    string value = infoAndValue[1];
                    AddToPeopleWithInformation(name, info, value, peopleWithInformation);
                }
            }

            string[] killCommand = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string victim = killCommand[1];
            PrintVictimInfo(victim, peopleWithInformation);
        }

        private static void PrintVictimInfo(string victim, Dictionary<string, SortedDictionary<string, string>> peopleWithInformation)
        {
            long infoIndex = 0;
            Console.WriteLine($"Info on {victim}:");
            foreach (var info in peopleWithInformation[victim])
            {
                infoIndex += info.Key.Length;
                infoIndex += info.Value.Length;
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                long infoNeeded = targetInfoIndex - infoIndex;
                Console.WriteLine($"Need {infoNeeded} more info.");
            }
        }

        private static void AddToPeopleWithInformation(string name, string info, string value, Dictionary<string, SortedDictionary<string, string>> peopleWithInformation)
        {
            if (!peopleWithInformation.ContainsKey(name))
            {
                peopleWithInformation.Add(name, new SortedDictionary<string, string>());
                peopleWithInformation[name].Add(info, value);
            }
            else
            {
                if (!peopleWithInformation[name].ContainsKey(info))
                {
                    peopleWithInformation[name].Add(info, value);
                }
                else
                {
                    peopleWithInformation[name][info] = value;
                }
            }
        }
    }
}
