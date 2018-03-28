using System;
using System.Collections.Generic;
using System.Text;

namespace P06StrategyPattern
{
    class StartUp
    {
        static void Main()
        {
            SortedSet<Person> sortedByName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> sortedByAge = new SortedSet<Person>(new AgeComparator());

            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var args = Console.ReadLine().Split();
                var name = args[0];
                var age = int.Parse(args[1]);
                Person person = new Person(name, age);
                sortedByName.Add(person);
                sortedByAge.Add(person);
            }

            Console.WriteLine(PrintSortedSet(sortedByName));
            Console.WriteLine(PrintSortedSet(sortedByAge));
        }

        private static string PrintSortedSet(SortedSet<Person> sortedSet)
        {
            var builder = new StringBuilder();
            foreach (var person in sortedSet)
            {
                builder.AppendLine(person.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
