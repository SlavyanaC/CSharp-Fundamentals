using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Salary
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
                var salary = decimal.Parse(tokens[3]);
                var person = new Person(firstName, lastName, age, salary);
                people.Add(person);
            }

            decimal bonus = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(bonus));
            people.ForEach(p => Console.WriteLine(p.ToString()));
            
        }
    }
}
