using System;
using System.Collections.Generic;
using System.Text;

namespace P07EqualityLogic
{
    class StartUp
    {
        static void Main()
        {
            SortedSet<Person> sorted = new SortedSet<Person>();
            HashSet<Person> hash = new HashSet<Person>();

            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var args = Console.ReadLine().Split();
                var name = args[0];
                var age = int.Parse(args[1]);
                Person person = new Person(name, age);

                sorted.Add(person);
                hash.Add(person);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hash.Count);
        }
    }
}
