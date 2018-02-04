using System;
using System.Collections.Generic;
using System.Linq;

public class PredicateParty
{
    public static void Main()
    {
        List<string> guests = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "Party!")
            {
                break;
            }
            var intputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = intputArgs[0];
            string criteria = intputArgs[1];
            string condition = intputArgs[2];

            switch (criteria)
            {
                case "StartsWith":
                    ApplyChanges(guests, command, n => n.StartsWith(condition));
                    break;
                case "EndsWith":
                    ApplyChanges(guests, command, n => n.EndsWith(condition));
                    break;
                case "Length":
                    int length = int.Parse(condition);
                    ApplyChanges(guests, command, n => n.Length == length);
                    break;
            }
        }

        if (guests.Count == 0)
        {
            Console.WriteLine("Nobody is going to the party!");
        }
        else
        {
            Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
        }
    }

    private static void ApplyChanges(List<string> guests, string command, Func<string, bool> filter)
    {
        for (int i = guests.Count - 1; i >= 0; i--)
        {
            if (filter(guests[i]))
            {
                if (command == "Double")
                {
                    guests.Add(guests[i]);
                }
                else if (command == "Remove")
                {
                    guests.RemoveAt(i);
                }
            }
        }
    }
}