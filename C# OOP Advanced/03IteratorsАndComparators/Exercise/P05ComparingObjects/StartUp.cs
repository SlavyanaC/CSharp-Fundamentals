using System;
using System.Collections.Generic;

namespace P05ComparingObjects
{
    class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            var inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var args = inputLine.Split();
                var name = args[0];
                var age = int.Parse(args[1]);
                var town = args[2];
                Person person = new Person(name, age, town);
                people.Add(person);
            }

            var personIndex = int.Parse(Console.ReadLine());
            Person wantedPerson = people[personIndex - 1];

            var equalCount = 0;
            foreach (var person in people)
            {
                if (person.CompareTo(wantedPerson) == 0)
                {
                    equalCount++;
                }
            }

            if (equalCount == 1)
                Console.WriteLine("No matches");
            else
            {
                var totalCount = people.Count;
                var notEqualPeople = totalCount - equalCount;
                Console.WriteLine($"{equalCount} {notEqualPeople} {totalCount}");
            }
        }
    }
}
