using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Events
{
    class Events
    {
        static string location;
        static string person;
        static string hour;

        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"^#(?<person>[A-Za-z]+):\s*@(?<location>[A-Za-z]+)\s*(?<hour>[0-2][0-9]:[0-5][0-9])$");
            int n = int.Parse(Console.ReadLine());
            var dictionary = new SortedDictionary<string, SortedDictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (pattern.IsMatch(input))
                {
                    var match = pattern.Match(input);
                    location = match.Groups["location"].Value;
                    person = match.Groups["person"].Value;
                    hour = match.Groups["hour"].Value;

                    string[] hourAndMins = hour.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string hr = hourAndMins[0];
                    string min = hourAndMins[1];
                    if (hr == "24" || hr == "60")
                    {
                        continue;
                    }
                    AddLocationPersonAndHour(dictionary);
                }
            }

            string[] locations = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            PrintLocations(locations, dictionary);
        }

        private static void PrintLocations(string[] locations, SortedDictionary<string, SortedDictionary<string, List<string>>> dictionary)
        {
            foreach (var local in locations.OrderBy(l => l))
            {
                int counter = 1;
                if (dictionary.ContainsKey(local))
                {
                    Console.WriteLine($"{local}:");
                    foreach (var person in dictionary[local])
                    {
                        Console.WriteLine($"{counter}. {person.Key} -> {string.Join(", ", person.Value.OrderBy(h => h))}");
                        counter++;
                    }
                }
            }
        }

        private static void AddLocationPersonAndHour(SortedDictionary<string, SortedDictionary<string, List<string>>> dictionary)
        {
            if (!dictionary.ContainsKey(location))
            {
                dictionary.Add(location, new SortedDictionary<string, List<string>>());
                dictionary[location].Add(person, new List<string>());
                dictionary[location][person].Add(hour);
            }
            else
            {
                if (!dictionary[location].ContainsKey(person))
                {
                    dictionary[location].Add(person, new List<string>());
                    dictionary[location][person].Add(hour);
                }
                else
                {
                    dictionary[location][person].Add(hour);
                }
            }
        }
    }
}
