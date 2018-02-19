using System;
using System.Collections.Generic;

namespace _03Validation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split();
                try
                {
                    var firstName = tokens[0];
                    var lastName = tokens[1];
                    var age = int.Parse(tokens[2]);
                    var salary = decimal.Parse(tokens[3]);
                    var person = new Person(firstName, lastName, age, salary);
                    people.Add(person);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }

            decimal bonus = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(bonus));
            people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
