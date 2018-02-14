using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                var person = new Person(name, age);
                people.Add(person);
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine(person.Name + " - " + person.Age);
            }
        }
    }
}
