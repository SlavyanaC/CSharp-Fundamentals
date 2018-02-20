using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var bagItems = new Dictionary<string, Dictionary<string, long>>();
        long bagCapacity = long.Parse(Console.ReadLine());

        string[] jewels = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < jewels.Length; i += 2)
        {
            string name = jewels[i];
            long amount = long.Parse(jewels[i + 1]);

            string jewelsType = string.Empty;
            jewelsType = GetJewelsType(name, jewelsType);

            if (jewelsType == string.Empty || bagCapacity < bagItems.Values.Select(x => x.Values.Sum()).Sum() + amount)
            {
                continue;
            }

            switch (jewelsType)
            {
                case "Gem":
                    if (!bagItems.ContainsKey(jewelsType))
                    {
                        if (bagItems.ContainsKey("Gold"))
                        {
                            if (amount > bagItems["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bagItems[jewelsType].Values.Sum() + amount > bagItems["Gold"].Values.Sum())
                    {
                        continue;
                    }
                    break;
                case "Cash":
                    if (!bagItems.ContainsKey(jewelsType))
                    {
                        if (bagItems.ContainsKey("Gem"))
                        {
                            if (amount > bagItems["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bagItems[jewelsType].Values.Sum() + amount > bagItems["Gem"].Values.Sum())
                    {
                        continue;
                    }
                    break;
            }

            if (!bagItems.ContainsKey(jewelsType))
            {
                bagItems[jewelsType] = new Dictionary<string, long>();
            }

            if (!bagItems[jewelsType].ContainsKey(name))
            {
                bagItems[jewelsType][name] = 0;
            }

            bagItems[jewelsType][name] += amount;
        }

        PrintResult(bagItems);
    }

    private static string GetJewelsType(string name, string jewelsType)
    {
        if (name.Length == 3)
        {
            jewelsType = "Cash";
        }
        else if (name.ToLower().EndsWith("gem"))
        {
            jewelsType = "Gem";
        }
        else if (name.ToLower() == "gold")
        {
            jewelsType = "Gold";
        }

        return jewelsType;
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, long>> bagItems)
    {
        foreach (var x in bagItems)
        {
            Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
            foreach (var item in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }
    }
}