using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Persons
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split();
                var firstName = tokens[0];
                var lastName = tokens[1];
                var age = int.Parse(tokens[2]);
                var person = new Person(firstName, lastName, age);
                people.Add(person);
            }

            people.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
