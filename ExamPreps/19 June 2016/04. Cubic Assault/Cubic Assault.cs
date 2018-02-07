using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cubic_Assault
{
    class Program
    {
        //70/100
        static void Main(string[] args)
        {
            var regionsWithMeteorsAndCount = new Dictionary<string, Dictionary<string, long>>();
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "Count em all")
            {
                var tokens = command.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                var region = tokens[0];
                var meteorType = tokens[1];
                var count = long.Parse(tokens[2]);

                if (!regionsWithMeteorsAndCount.ContainsKey(region))
                {
                    regionsWithMeteorsAndCount.Add(region, new Dictionary<string, long>());
                    regionsWithMeteorsAndCount[region].Add("Black", 0);
                    regionsWithMeteorsAndCount[region].Add("Red", 0);
                    regionsWithMeteorsAndCount[region].Add("Green", 0);
                }
                if (regionsWithMeteorsAndCount[region].ContainsKey(meteorType))
                {
                    regionsWithMeteorsAndCount[region][meteorType] += count;
                }

                var greens = regionsWithMeteorsAndCount[region]["Green"];
                var convertedGreen = greens / 1_000_000;
                regionsWithMeteorsAndCount[region]["Red"] += convertedGreen;
                regionsWithMeteorsAndCount[region]["Green"] -= convertedGreen * 1_000_000;

                var reds = regionsWithMeteorsAndCount[region]["Red"];
                var convertedRed = reds / 1_000_000;
                regionsWithMeteorsAndCount[region]["Black"] += convertedRed;
                regionsWithMeteorsAndCount[region]["Red"] -= convertedRed * 1_000_000;


            }

            foreach (var kvp in regionsWithMeteorsAndCount.OrderByDescending(m => m.Value["Black"]).ThenBy(m => m.Key.Length).ThenBy(m => m.Key))
            {
                string meteor = kvp.Key;
                var meteInfo = kvp.Value;
                Console.WriteLine(meteor);

                foreach (var mete in meteInfo.OrderByDescending(c => c.Value).ThenBy(c => c.Key))
                {
                    Console.WriteLine($"-> {mete.Key} : {mete.Value}");
                }
            }

        }
    }
}

