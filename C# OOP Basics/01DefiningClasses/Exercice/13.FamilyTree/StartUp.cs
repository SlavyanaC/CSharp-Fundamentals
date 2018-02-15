using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();
        var wantedPerson = Console.ReadLine();

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End") break;

            if (input.Contains("-"))
            {
                var tokens = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToArray();
                var parentInfo = tokens[0];
                var childInfo = tokens[1];

                var parent = CreatePerson(parentInfo);
                var child = CreatePerson(childInfo);

                AddParent(people, parent);

                if (parent.Name != null)
                {
                    people.FirstOrDefault(p => p.Name == parent.Name)
                          .AddChild(child);
                }
                else
                {
                    people.FirstOrDefault(p => p.Birthday == parent.Birthday)
                          .AddChild(child);
                }
            }
            else
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{tokens[0]} {tokens[1]}";
                var birthdate = tokens[2];
                var personExists = false;

                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Name == name)
                    {
                        people[i].Birthday = birthdate;
                        personExists = true;
                    }
                    if (people[i].Birthday == birthdate)
                    {
                        people[i].Name = name;
                        personExists = true;
                    }
                    people[i].AddChildInfo(name, birthdate);
                }

                if (!personExists)
                {
                    people.Add(new Person(name, birthdate));
                }
            }
        }

        PrintParentsAndChildren(people, wantedPerson);
    }

    private static Person CreatePerson(string personParam)
    {
        var person = new Person();
        if (IsDate(personParam))
        {
            person.Birthday = personParam;
        }
        else
        {
            person.Name = personParam;
        }

        return person;
    }

    private static void PrintParentsAndChildren(List<Person> people, string personParam)
    {
        Person person = people.FirstOrDefault(p => p.Birthday == personParam || p.Name == personParam);

        var builder = new StringBuilder();
        builder.AppendLine($"{person.Name} {person.Birthday}");

        builder.AppendLine("Parents:");
        people.Where(p => p.FindChild(person.Name) != null)
              .ToList()
              .ForEach(p => builder.AppendLine($"{p.Name} {p.Birthday}"));

        builder.AppendLine("Children:");
        person.Children
              .ToList()
              .ForEach(c => builder.AppendLine($"{c.Name} {c.Birthday}"));

        Console.WriteLine(builder);
    }

    private static void AddParent(List<Person> people, Person parent)
    {
        if ((parent.Name != null && people.Any(p => p.Name == parent.Name)) ||
            (parent.Birthday != null & people.Any(p => p.Birthday == parent.Birthday)))
        {
            return;
        }

        people.Add(parent);
    }

    public static bool IsDate(string input)
    {
        return input.Contains("/");
    }
}